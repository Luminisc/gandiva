using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gandiva.Data;
using Gandiva.Models;

namespace Gandiva.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index()
        {
            var current = new TaskRepository().Get(3);
            var model = new TasksViewModel(current);
            return View(model);
        }
    }
}