using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gandiva.Business.Entity;
using Gandiva.Models;

namespace Gandiva.Models
{
	public static class Convertions
	{
		public static TaskListItemViewModel ConvertToViewModel(this TaskListItem item)
		{
			return new TaskListItemViewModel {
				Id = item.Id,
				Title = item.Title,
				Creator = item.Creator,
				Contractor = item.Contractor,
				CreatedDate = item.CreatedDate.ToString()
			};
		}

		public static UserViewModel ConvertToViewModel(this User item)
		{
			return new UserViewModel
			{
				Id = item.Id,
				FirstName = item.FirstName,
				SecondaryName = item.SecondaryName,
				Surname = item.Surname
			};
		}
	}
}