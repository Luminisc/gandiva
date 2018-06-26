using System.Collections.Generic;
using System.Linq;
using Gandiva.Business.Entity;
using Gandiva.Data;
using Gandiva.Common;

namespace Gandiva.Business
{
	public static class TasksService
	{
		public static IEnumerable<TaskListItem> GetTasksList()
		{
			/* Получаем текущие таски */
			var tasks = new TaskRepository().Get().Where(x => x.IsActual).ToList();
			return tasks.Select(task => new TaskListItem
			{
				Id = task.Id,
				Title = task.Title,
				Creator = task.TaskCreator.FullName(),
				Contractor = task.TaskContractor.FullName(),
				CreatedDate = task.CreatedDate
			});
		}

		public static Task GetTask(int id)
		{
			var task = new TaskRepository().Get(id);
			if (task == null)
				throw new System.Exception("No tasks with such ID");
			return new Task
			{
				Id = task.Id,
				Title = task.Title,
				Description = task.Description,
				Creator = task.Creator,
				Contractor = task.Contractor,
				CreatedDate = task.CreatedDate
			};
		}

		public static bool SaveTask(Task task, IEnumerable<Comment> comments)
		{
			bool successful = true;

			try
			{
				var taskRepo = new TaskRepository();
				var commentsRepo = new CommentRepository();

				var taskForUpdate = taskRepo.Get(task.Id);
				if (taskForUpdate == null)
					return false;
				taskForUpdate.Title = task.Title;
				taskForUpdate.Description = task.Description;
				taskForUpdate.Creator = task.Creator;
				taskForUpdate.Contractor = task.Contractor;
				taskRepo.Update(taskForUpdate);
				var dbcomments = taskForUpdate.Comments;
				foreach (var item in dbcomments)
				{
					commentsRepo.Delete(item);
				}
				foreach (var comment in comments)
				{
					commentsRepo.Create(new Data.Entity.Comment
					{
						Creator = comment.Creator,
						Description = comment.Description,
						Task = taskForUpdate.Id
					});
				}
			}
			catch (System.Exception ex)
			{
				successful = false;
			}

			return successful;
		}

		public static bool CreateTask(Task task, IEnumerable<Comment> comments)
		{
			bool successful = true;
			try
			{
				var taskRepo = new TaskRepository();
				var CreatedTask = taskRepo.Create(new Data.Entity.Task()
				{
					Title = task.Title,
					Description = task.Description,
					Creator = task.Creator,
					Contractor = task.Contractor,
					CreatedDate = System.DateTime.Now
				});
				var commentsRepo = new CommentRepository();
				foreach (var comment in comments)
				{
					commentsRepo.Create(new Data.Entity.Comment
					{
						Creator = comment.Creator,
						Description = comment.Description,
						Task = CreatedTask.Id
					});
				}
			}
			catch (System.Exception ex)
			{
				successful = false;
			}
			return successful;
		}

		public static bool DeleteTask(int taskId)
		{
			var taskRepo = new TaskRepository();
			var dbtask = taskRepo.Get(taskId);
			if (dbtask != null)
			{
				taskRepo.Delete(dbtask);
				return true;
			}
			return false;
		}
	}
}