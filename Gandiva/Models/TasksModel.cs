using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gandiva.Models
{
    public class TasksModel
    {
        public TasksModel()
        {

        }
        public List<Task> Tasks = new List<Task>();
    }

    public class Task
    {
        public Task(string title, string creator, string executer, DateTime creationTime)
        {
            Id = new Random().Next();
            Title = title;
            Creator = creator;
            Executor = executer;
            CreationTime = creationTime;
        }

        public int Id { get; protected set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public string Executor { get; set; }
        public DateTime CreationTime { get; set; }
    }
}