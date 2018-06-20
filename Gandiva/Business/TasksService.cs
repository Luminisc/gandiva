using System.Collections.Generic;
using System.Linq;
using Gandiva.Business.Entity;
using Gandiva.Data;

namespace Gandiva.Business
{
    public static class TasksService
    {
        public static IEnumerable<TaskListItem> GetTasksList()
        {
            var tasks = (from task in GandivaContext.Context.Tasks
                where task.IsActual
                select task).ToList();
            var usersIdOfTasks = tasks.Select(task => task.Creator).Concat(tasks.Select(task => task.Contractor)).Distinct().ToList();
            var names = (from user in GandivaContext.Context.Users
                where usersIdOfTasks.Contains(user.Id)
                select new {user.Id, user.FirstName, user.SurName}).ToList();

            return tasks.Select(task => new TaskListItem
            {
                Id = task.Id,
                Title = task.Title,
                Creator = names.Where(usr => usr.Id == task.Creator).Select(usr =>
                    string.Format("{0} {1}", usr.FirstName, usr.SurName)).First(),
                Contractor = names.Where(usr => usr.Id == task.Contractor).Select(usr =>
                    string.Format("{0} {1}", usr.FirstName, usr.SurName)).First(),
                CreatedDate = task.CreatedDate
            });
        }
    }
}