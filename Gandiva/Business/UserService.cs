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
		public static IEnumerable<User> GetUsers(bool onlyActual = true)
		{
			var dbUsers = from user in GandivaContext.Context.Users
						  select user;
			if (onlyActual)
				dbUsers = dbUsers.Where(user => user.IsActual);
			return dbUsers.Select(e => new User { Id = e.Id, FirstName = e.FirstName, SecondaryName = e.SecondaryName, Surname = e.SurName });
		}
	}
}