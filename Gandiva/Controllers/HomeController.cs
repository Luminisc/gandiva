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
            var users = UserService.Get().Select(e => e.ToViewModel()).ToList();
            return View(new UsersModel { Users = users });
        }

        public ActionResult TasksList(int currentPage = 0)
        {
            var model = new TasksListViewModel { Tasks = GetTasks(currentPage) };
            ViewBag.Pages = Math.Ceiling(model.Tasks.Count() / (float)ITEMS_PER_PAGE);
            return PartialView(model);
        }

        static IEnumerable<TaskListItemViewModel> GetTasks(int currentPage)
        {
            var tasks = TasksService.GetTasksList().Select(task => task.ToViewModel());
            return tasks.Skip(currentPage * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE);
        }
    }
}