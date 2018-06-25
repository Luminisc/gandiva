using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gandiva.Business.Entity
{
	public class Task
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Creator { get; set; }
		public int Contractor { get; set; }
		public DateTime CreatedDate { get; set; }

		//public IEnumerable<>
	}
}