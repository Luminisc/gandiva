using System.Collections.Generic;

namespace Gandiva.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondaryName { get; set; }
        public string Surname { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, Surname); } }
    }

    public class UsersViewModel
    {
        public UserViewModel ActiveUser;
        public IEnumerable<UserViewModel> Users = new List<UserViewModel>();
    }
}