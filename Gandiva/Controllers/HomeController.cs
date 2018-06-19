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
            homeModel.Users.Add(new User(0, "Alex", "Rmnko"));
            homeModel.Users.Add(new User(1, "Kirill", "Churin"));
            homeModel.Users.Add(new User(2, "Ivan", "Ivanov"));

            return View(homeModel);
        }
    }
}