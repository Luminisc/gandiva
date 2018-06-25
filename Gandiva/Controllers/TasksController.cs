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
			ViewBag.CommentsPartialViewLink = Url.Action("CommentsList", "Tasks", null, Request.Url.Scheme);
			ViewBag.TasksCommentsPartialViewLink = Url.Action("TaskCommentsList", "Tasks", null, Request.Url.Scheme);
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

		public ActionResult CommentsList(CommentsViewModel model, int? delete)
		{
			var comments = model.Comments;
			if (delete.HasValue)
			{
				comments = comments.Take(delete.Value).Concat(comments.Skip(delete.Value + 1).Take(comments.Count() - 1 - delete.Value));
			}
			model.Comments = comments;
			ViewBag.Users = UserService.GetUsers().Select(user => user.ToViewModel()).ToDictionary(x => x.Id, x => x.FullName);
			return View("CommentsList", model);
		}

		public ActionResult TaskCommentsList(int taskId)
		{
			var comments = CommentService.GetComments(taskId).Select(comment => comment.ToViewModel());
			var model = new CommentsViewModel { Comments = comments };
			return CommentsList(model, null);
		}
	}
}