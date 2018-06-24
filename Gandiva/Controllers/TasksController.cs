using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Gandiva.Business;
using Gandiva.Models;
using Gandiva.Common;

namespace Gandiva.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index(int? taskId = 1)
        {
			if (!taskId.HasValue) return NewTaskView();
			var model = TasksService.GetTask(taskId.Value).ToViewModel();
			model.Users = UserService.GetUsers().Select(user => user.ToViewModel()).OrderBy(x => x.FullName);
			model.Comments = CommentService.GetComments(taskId.Value).Select(comment => comment.ToViewModel());
            return View(model);
        }

		public ActionResult NewTaskView()
		{
			TasksViewModel model = new TasksViewModel() {
				CreatedDate = DateTime.Now.ToString()
			};
			model.Users = UserService.GetUsers().Select(user => user.ToViewModel()).OrderBy(x => x.FullName);
			return View("Index", model);
		}

		public ActionResult SubmitForm(TasksViewModel model)
		{
			// if all good -> save and return to home
			// else send to index with error for ex.
			return View("Index");
		}

		public ActionResult CommentsList(IEnumerable<CommentViewModel> comments)
		{

			return View(comments);
		}

		public ActionResult CommentsList(int taskId)
		{
			var model = CommentService.GetComments(taskId).Select(comment => comment.ToViewModel());
			return View(model);
		}
	}
}