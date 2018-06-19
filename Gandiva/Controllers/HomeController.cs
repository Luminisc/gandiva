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
        public ActionResult Index()
        {
            var homeModel = new HomeModel();
            homeModel.Users.Add(new User(0, "Alex Rmnko"));
            homeModel.Users.Add(new User(1, "Kirill Churin"));
            homeModel.Users.Add(new User(2, "Ivan Ivanov"));

            return View(homeModel);
        }

        public ActionResult TasksList()
        {
            var model = new TasksModel();
            model.Tasks.Add(new Task("Task 1", "Creater 1", "Executer 1", DateTime.Now));
            model.Tasks.Add(new Task("Task 2", "Creater 2", "Executer 2", DateTime.Now));
            model.Tasks.Add(new Task("Task 3", "Creater 3", "Executer 3", DateTime.Now));

            return PartialView(model);
        }
    }
}