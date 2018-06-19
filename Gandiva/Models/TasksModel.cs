using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gandiva.Models
{
    public class TasksListViewModel
    {
        public List<TaskListItemViewModel> Tasks = new List<TaskListItemViewModel>();
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