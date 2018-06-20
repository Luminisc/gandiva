using System.Collections.Generic;

namespace Gandiva.Models
{
    public class TasksListViewModel
    {
        public IEnumerable<TaskListItemViewModel> Tasks = new List<TaskListItemViewModel>();
    }

    public class TaskListItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public string Contractor { get; set; }
        public string CreatedDate { get; set; }
    }
}