using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gandiva.Business.Entity
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string SecondaryName { get; set; }
		public string Surname { get; set; }
	}

	public class Task
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Creator { get; set; }
		public string Contractor { get; set; }
		public DateTime CreatedDate { get; set; }
	}

	public class TaskListItem
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Creator { get; set; }
		public string Contractor { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}