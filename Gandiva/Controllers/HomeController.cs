using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Gandiva.Business;
using Gandiva.Common;
using Gandiva.Models;

namespace Gandiva.Controllers
{
	public class HomeController : Controller
	{
		const int ITEMS_PER_PAGE = 5;

		public ActionResult Index()
		{
			ViewBag.TablePartialViewLink = Url.Action("TasksList", "Home", null, Request.Url.Scheme);
			var users = UserService.GetUsers().Select(e => e.ToViewModel()).OrderBy(e => e.FullName).ToList();
			return View(new UsersViewModel { Users = users });
		}

		public ActionResult TasksList(int page = 0)
		{
			var tasks = TasksService.GetTasksList().Select(task => task.ToViewModel());
			var displayedTasks = tasks.Skip(page * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE);
			var model = new HomeViewModel { Tasks = displayedTasks };
			ViewBag.Pages = Math.Ceiling(tasks.Count() / (float)ITEMS_PER_PAGE);
			return PartialView(model);
		}
	}
}