using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gandiva.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
			ViewBag.TablePartialViewLink = Url.Action("UsersList", "Users", null, Request.Url.Scheme) + "?currentPage=";
			return View();
        }

		public ActionResult UsersList(int currentPage = 0)
		{
			//var tasks = TasksService.GetTasksList().Select(task => task.ToViewModel());
			//var displayedTasks = tasks.Skip(currentPage * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE);
			//var model = new HomeViewModel { Tasks = displayedTasks };
			//ViewBag.Pages = Math.Ceiling(tasks.Count() / (float)ITEMS_PER_PAGE);
			//return PartialView(model);
			return PartialView();
		}
	}
}