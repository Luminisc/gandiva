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
            /* Получаем текущие таски */
            var tasks = (from task in new TaskRepository().Get()
                         where task.IsActual
                         select task).ToList();
            /* Получаем Id всех создателей и исполнителей тасков */
            var usersIdOfTasks = tasks.Select(task => task.Creator).Concat(tasks.Select(task => task.Contractor)).Distinct().ToList();
            /* */
            var names = (from user in new UserRepository().Get()
                         where usersIdOfTasks.Contains(user.Id)
                         select new { user.Id, FullName = user.FirstName + " " + user.SurName }).ToList();

            return tasks.Select(task => new TaskListItem
            {
                Id = task.Id,
                Title = task.Title,
                Creator = names.Where(usr => usr.Id == task.Creator).Select(usr => usr.FullName).Single(),// ожидаем только 1 элемент 
                Contractor = names.Where(usr => usr.Id == task.Contractor).Select(usr => usr.FullName).Single(),
                CreatedDate = task.CreatedDate
            });
        }
    }
}