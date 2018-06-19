using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

//using Gandiva.Data;
using Gandiva.Models;
using Gandiva.Business;

namespace Gandiva.Controllers
{
	public class HomeController : Controller
	{
		List<Task> tasks = new List<Task>();
		int itemsPerPage = 5;

		public HomeController()
		{
			for (int i = 0; i < 23; i++)
			{
				tasks.Add(new Task("Task " + i, "Creater " + i, "Executer " + i, DateTime.Now));
			}
		}

		public ActionResult Index()
		{
			var users = UserService.GetUsers().Select(e => new UserViewModel() { Id = e.Id, FirstName = e.FirstName, SecondaryName = e.SecondaryName, Surname = e.Surname }).ToList();
			return View(new UsersModel() {
				Users = users
			});
		}

		public ActionResult TasksList(int startPage = 0)
		{
			var taskModel = new TasksModel();
			taskModel.Tasks = GetTasks(startPage);
			ViewBag.Pages = Math.Ceiling(tasks.Count / (float)itemsPerPage);
			return PartialView(taskModel);
		}

		List<Task> GetTasks(int startPage)
		{
			return tasks.Skip(startPage * itemsPerPage).Take(itemsPerPage).ToList();
		}
	}
}