using System.Collections.Generic;
using System.Linq;
using Gandiva.Business.Entity;
using Gandiva.Data;

namespace Gandiva.Business
{
    public static class UserService
    {
        public static IEnumerable<User> GetUsers()
        {
            var users = from user in GandivaContext.Context.Users
                          where user.IsActual
                          select user;
            return users.Select(e => new User { Id = e.Id, FirstName = e.FirstName, SecondaryName = e.SecondaryName, Surname = e.SurName });
        }
    }
}