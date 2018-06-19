using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gandiva.Models
{
    public class UserViewModel
    {
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string SecondaryName { get; set; }
		public string Surname { get; set; }
		public string FullName { get { return String.Format($"{FirstName} {Surname}"); } }
    }
    public class UsersModel
    {
        public List<UserViewModel> Users = new List<UserViewModel>();
        public UserViewModel ActiveUser;
    }
}