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
			var users = new UserRepository().Get().Where(u => u.IsActual);
			return users.Select(e => new User { Id = e.Id, FirstName = e.FirstName, SecondaryName = e.SecondaryName, Surname = e.SurName });
		}

		public static void UpdateUser(User user)
		{
			var users = new UserRepository();
			var dbUser = users.Get(user.Id);
			if (dbUser != null)
			{
				dbUser.FirstName = user.FirstName;
				dbUser.SecondaryName = user.SecondaryName;
				dbUser.SurName = user.Surname;
				users.Update(dbUser);
			}
		}

		public static void DeleteUser(int id)
		{
			var users = new UserRepository();
			var user = users.Get(id);
			if (users.Get(id) != null)
				users.Delete(user);
		}

		public static void CreateUser(User user)
		{
			new UserRepository().Create(
				new Data.Entity.User()
				{
					FirstName = user.FirstName,
					SecondaryName = user.SecondaryName,
					SurName = user.Surname,
					CreatedDate = System.DateTime.Now
				});
		}
	}
}