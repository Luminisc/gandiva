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
			ViewBag.TablePartialViewLink = Url.Action("TasksList", "Home", null, Request.Url.Scheme) + "?currentPage=";
            var users = UserService.GetUsers().Select(e => e.ToViewModel()).ToList();
			return View(new UsersModel { Users = users });
        }

        public ActionResult TasksList(int currentPage = 0)
        {
			var tasks = TasksService.GetTasksList().Select(task => task.ToViewModel());
			var displayedTasks = tasks.Skip(currentPage * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE);
			var model = new TasksListViewModel { Tasks = displayedTasks };
            ViewBag.Pages = Math.Ceiling(tasks.Count() / (float)ITEMS_PER_PAGE);
            return PartialView(model);
        }
    }
}