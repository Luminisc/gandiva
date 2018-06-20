using Gandiva.Business.Entity;
using Gandiva.Models;

namespace Gandiva.Common
{
    public static class Extentions
    {
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
    }
}