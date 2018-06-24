using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gandiva.Business;
using Gandiva.Data;
using Gandiva.Models;
using Gandiva.Common;

namespace Gandiva.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index(int taskId = 0)
        {
			taskId = 3;
			var model = TasksService.GetTask(taskId).ToViewModel();
			model.Users = UserService.GetUsers().Select(user => user.ToViewModel());
            return View(model);
        }
    }
}