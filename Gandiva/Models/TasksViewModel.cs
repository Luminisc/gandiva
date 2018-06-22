using System.Collections.Generic;
using System.Linq;
using Gandiva.Data;
using Gandiva.Data.Entity;

namespace Gandiva.Models
{
    public class TasksViewModel
    {
        public TasksViewModel()
        {
            Task = new Task();
            Users = new UserRepository().Get().OrderBy(x => x.SurName).ToList();
        }

        public TasksViewModel(Task task)
            : this()
        {
            Task = task;
            IsEdit = true;
        }

        public Task Task { get; private set; }
        public IEnumerable<User> Users { get; private set; }
        public bool IsEdit { get; set; }
    }
}