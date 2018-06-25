using System;
using System.Linq;
using System.Web.Mvc;
using Gandiva.Business;
using Gandiva.Common;
using Gandiva.Models;

namespace Gandiva.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index(int? taskId)
        {
            ViewBag.CommentsPartialViewLink = Url.Action("CommentsList", "Tasks", null, Request.Url.Scheme);
            ViewBag.TasksCommentsPartialViewLink = Url.Action("TaskCommentsList", "Tasks", null, Request.Url.Scheme);
            if (!taskId.HasValue) return NewTaskView();
            var model = TasksService.GetTask(taskId.Value).ToViewModel();
            model.Users = UserService.GetUsers().Select(user => user.ToViewModel()).OrderBy(x => x.FullName);
            model.Comments = CommentService.GetComments(taskId.Value).Select(comment => comment.ToViewModel());

            var activeUser = -1;
            if (Request.Cookies["activeUser"] != null)
                activeUser = model.Users.Single(x => x.Id == int.Parse(Request.Cookies["activeUser"].Value)).Id;
            else
                activeUser = 1;
            ViewBag.ActiveUser = activeUser;
            ViewBag.TaskId = model.Id.HasValue ? model.Id.Value.ToString() : "";
            return View(model);
        }

        public ActionResult NewTaskView()
        {
            TasksViewModel model = new TasksViewModel
            {
                CreatedDate = DateTime.Now.ToString()
            };
            model.Users = UserService.GetUsers().Select(user => user.ToViewModel()).OrderBy(x => x.FullName);
            var activeUser = -1;
            if (Request.Cookies["activeUser"] != null)
                activeUser = model.Users.Single(x => x.Id == int.Parse(Request.Cookies["activeUser"].Value)).Id;
            model.Creator = activeUser;
            return View("Index", model);
        }

        public ActionResult SubmitTask(TasksViewModel model)
        {
            bool result = true;
            if (model.Comments == null)
                model.Comments = new CommentViewModel[] { };
            if (model.Id.HasValue)
                result = TasksService.SaveTask(model.ToModel(), model.Comments.Select(x => x.ToModel()));
            else
            {
                model.CreatedDate = DateTime.Now.ToString();
                result = TasksService.CreateTask(model.ToModel(), model.Comments.Select(x => x.ToModel()));
            }

            if (result)
                return RedirectToAction("Index", "Home");
            return View("Index", model);
        }

        public ActionResult DeleteTask(int taskId)
        {
            //remove
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CommentsList(CommentsViewModel model, CommentViewModel newComment, string action)
        {
            if (action != null)
            {
                var comments = model.Comments;
                if (action.ToLower().StartsWith("delete"))
                {
                    var delete = int.Parse(action.Substring(7));
                    comments = comments.Take(delete).Concat(comments.Skip(delete + 1).Take(comments.Count() - 1 - delete));
                }

                if (action.ToLower().StartsWith("add"))
                {
                    if (comments == null) comments = new CommentViewModel[] { };
                    comments = comments.Concat(new[] {newComment});
                }

                model.Comments = comments;
            }

            ViewBag.Users = UserService.GetUsers().Select(user => user.ToViewModel()).ToDictionary(x => x.Id, x => x.FullName);
            return View("CommentsList", model);
        }

        public ActionResult TaskCommentsList(int? taskId)
        {
            if (!taskId.HasValue) return CommentsList(new CommentsViewModel {Comments = new CommentViewModel[] { }}, null, null);
            var comments = CommentService.GetComments(taskId.Value).Select(comment => comment.ToViewModel());
            var model = new CommentsViewModel {Comments = comments};
            return CommentsList(model, null, null);
        }
    }
}