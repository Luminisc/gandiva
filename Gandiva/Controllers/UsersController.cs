﻿using Gandiva.Business;
using Gandiva.Common;
using Gandiva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gandiva.Controllers
{
	public class UsersController : Controller
	{
		const int ITEMS_PER_PAGE = 5;

		[HttpGet]
		public ActionResult Index()
		{
			ViewBag.TablePartialViewLink = Url.Action("UsersList", "Users", null, Request.Url.Scheme);
			return View();
		}

		[HttpPost]
		public ActionResult Index(UserViewModel _model, string action)
		{
			switch (action)
			{
				case "save":
					if (_model.IsValid()) UserService.UpdateUser(_model.ToModel());
					break;
				case "delete":
					if (_model.IsValid()) UserService.DeleteUser(_model.Id);
					break;
				case "create":
					if (_model.IsValid()) UserService.CreateUser(_model.ToModel());
					break;
			}
			return Index();
		}

		public ActionResult UsersList(int page = 0, bool withNew = false)
		{
			var users = UserService.GetUsers().Select(e => e.ToViewModel()).OrderBy(e => e.FullName);
			var displayedUsers = users.Skip(page * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE);
			ViewBag.Pages = Math.Ceiling(users.Count() / (float)ITEMS_PER_PAGE);
			ViewBag.ShowNewUserField = withNew;
			var model = new UsersViewModel { Users = displayedUsers };
			return PartialView(model);
		}
	}
}