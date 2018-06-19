using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gandiva.Business.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondaryName { get; set; }
        public string Surname { get; set; }
    }
}