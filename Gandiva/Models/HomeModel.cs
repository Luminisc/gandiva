using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gandiva.Models
{
    public class User
    {
        public User(int id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
        public int Id { get; protected set; }
        public string FullName { get; protected set; }
    }
    public class HomeModel
    {
        public HomeModel()
        {

        }
        public List<User> Users = new List<User>();
        public User ActiveUser;
    }
}