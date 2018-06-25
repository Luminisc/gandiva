using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gandiva.Business.Entity;
using Gandiva.Data;
using Gandiva.Common;

namespace Gandiva.Business
{
	public static class CommentService
	{
		public static IEnumerable<Comment> GetComments(int taskId)
		{
			return new CommentRepository().Get().Where(x => x.IsActual && x.Task == taskId)
				.Select(x => new Comment {
					Id = x.Id,
					Creator = x.Creator,
					Description = x.Description
				});
		}
	}
}