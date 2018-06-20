using System;

namespace Gandiva.Business.Entity
{
    public class TaskListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public string Contractor { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}