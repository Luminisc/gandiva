using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gandiva.Business.Entity;
using Gandiva.Data;

namespace Gandiva.Business
{
	public class UserService
	{
		public static IEnumerable<User> GetUsers()
		{
			var dbUsers = GandivaContext.Context.Users.ToList();
			return dbUsers.Select(e => new User { Id = e.Id, FirstName = e.FirstName, SecondaryName = e.SecondaryName, Surname = e.SurName });
		}
	}
}