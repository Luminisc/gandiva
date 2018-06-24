using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gandiva.Business.Entity
{
	public class Comment
	{
		public int Id { get; set; }

		public int Creator { get; set; }

		public string Description { get; set; }
	}
}