using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Gandiva.Models;
using Gandiva.Business;

namespace Gandiva.Controllers
{
	public class HomeController : Controller
	{
		int itemsPerPage = 5;

		public ActionResult Index()
		{
			var users = UserService.GetUsers().Select(e => e.ConvertToViewModel()).ToList();
			return View(new UsersModel() {
				Users = users
			});
		}

		public ActionResult TasksList(int startPage = 0)
		{
			var taskModel = new TasksListViewModel();
			taskModel.Tasks = GetTasks(0);
			ViewBag.Pages = Math.Ceiling(taskModel.Tasks.Count / (float)itemsPerPage);
			return PartialView(taskModel);
		}

		List<TaskListItemViewModel> GetTasks(int startPage)
		{
			var tasks = TasksService.GetTasksList().Select(task => task.ConvertToViewModel()).ToList();
			return tasks.Skip(startPage * itemsPerPage).Take(itemsPerPage).ToList();
		}
	}
}