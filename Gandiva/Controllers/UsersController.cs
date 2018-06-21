using Gandiva.Business;
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
			ViewBag.TablePartialViewLink = Url.Action("UsersList", "Users", null, Request.Url.Scheme) + "?currentPage=";
			return View();
        }

		[HttpPost]
		public ActionResult Index(UserViewModel _model, string action)
		{
			switch (action)
			{
				case "save":
					break;
				case "delete":
					break;
				default:
					break;
			}
			ViewBag.TablePartialViewLink = Url.Action("UsersList", "Users", null, Request.Url.Scheme) + "?currentPage=";
			return View();
		}

		[HttpGet]
		public ActionResult UsersList(int currentPage = 0)
		{
			var users = UserService.GetUsers().Select(e => e.ToViewModel()).ToList();
			var model = new UsersViewModel { Users = users };
			var displayedUsers = users.Skip(currentPage * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE);
			ViewBag.Pages = Math.Ceiling(users.Count() / (float)ITEMS_PER_PAGE);
			return PartialView(model);
		}
	}
}