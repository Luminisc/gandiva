using Gandiva.Business.Entity;
using Gandiva.Models;

namespace Gandiva.Common
{
	public static class Extentions
	{
		#region ToViewModel
		public static TaskListItemViewModel ToViewModel(this TaskListItem item)
		{
			return new TaskListItemViewModel
			{
				Id = item.Id,
				Title = item.Title,
				Creator = item.Creator,
				Contractor = item.Contractor,
				CreatedDate = item.CreatedDate.ToString()
			};
		}

		public static UserViewModel ToViewModel(this User item)
		{
			return new UserViewModel
			{
				Id = item.Id,
				FirstName = item.FirstName,
				SecondaryName = item.SecondaryName,
				Surname = item.Surname
			};
		}
		public static TasksViewModel ToViewModel(this Task item)
		{
			return new TasksViewModel
			{
				Id = item.Id,
				Title = item.Title,
				Description = item.Description,
				Creator = item.Creator,
				Contractor = item.Contractor,
				CreatedDate = item.CreatedDate.ToString()
			};
		}

		public static CommentViewModel ToViewModel(this Comment item)
		{
			return new CommentViewModel
			{
				Id = item.Id,
				Creator = item.Creator,
				Description = item.Description
			};
		}
		#endregion

		public static string FullName(this Gandiva.Data.Entity.User user)
		{
			return string.Format("{0} {1}", user.FirstName, user.SurName);
		}

		public static bool IsValid(this UserViewModel user)
		{
			return !string.IsNullOrWhiteSpace(user.FirstName)
				&& !string.IsNullOrWhiteSpace(user.SecondaryName)
				&& !string.IsNullOrWhiteSpace(user.Surname);
		}

		public static bool IsValid(this User user)
		{
			return !string.IsNullOrWhiteSpace(user.FirstName)
				&& !string.IsNullOrWhiteSpace(user.SecondaryName)
				&& !string.IsNullOrWhiteSpace(user.Surname);
		}

		public static User ToModel(this UserViewModel model)
		{
			return new User
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondaryName = model.SecondaryName,
				Surname = model.Surname
			};
		}

		public static Task ToModel(this TasksViewModel model)
		{
			return new Task
			{
				Id = model.Id.HasValue ? model.Id.Value : -1,
				Title = model.Title,
				Description = model.Description,
				Creator = model.Creator,
				Contractor = model.Contractor,
				CreatedDate = System.DateTime.Parse(model.CreatedDate)
			};
		}

		public static Comment ToModel(this CommentViewModel model)
		{
			return new Comment
			{
				Id = model.Id.HasValue ? model.Id.Value : -1,
				Creator = model.Creator,
				Description = model.Description
			};
		}
	}
}