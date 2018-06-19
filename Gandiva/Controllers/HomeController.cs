using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gandiva.Models;

namespace Gandiva.Controllers
{
    public class HomeController : Controller
    {
        List<Task> tasks = new List<Task>();
        List<User> users = new List<User>();
        int itemsPerPage = 5;

        public HomeController()
        {
            users.Add(new User(0, "Alex Rmnko"));
            users.Add(new User(1, "Kirill Churin"));
            users.Add(new User(2, "Ivan Ivanov"));

            for (int i = 0; i < 23; i++)
            {
                tasks.Add(new Task("Task " + i, "Creater " + i, "Executer " + i, DateTime.Now));
            }
        }

        public ActionResult Index()
        {
            var homeModel = new HomeModel();
            homeModel.Users = users;
            return View(homeModel);
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