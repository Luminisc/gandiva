using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gandiva.Models
{
    public class User
    {
        public User(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string VisibleName { get { return FirstName + " " + LastName; } }
        public int Id { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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