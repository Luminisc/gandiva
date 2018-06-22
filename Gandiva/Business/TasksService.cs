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
    }
}