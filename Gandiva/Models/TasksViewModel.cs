using System.Collections.Generic;
using System.Linq;

namespace Gandiva.Models
{
    public class TasksViewModel
    {
		public int? Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Creator { get; set; }
		public int Contractor { get; set; }
		public string CreatedDate { get; set; }
		public IEnumerable<UserViewModel> Users { get; set; }
		public IEnumerable<CommentViewModel> Comments { get; set; }
	}

	public class CommentViewModel
	{
		public int? Id { get; set; }

		public int Creator { get; set; }

		public string Description { get; set; }
	}

	public class CommentsViewModel
	{
		public IEnumerable<CommentViewModel> Comments { get; set; }
	}
}