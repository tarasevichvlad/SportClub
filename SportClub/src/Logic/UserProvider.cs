using System;
using System.Collections.Generic;
using SportClub.Interfaces;
using SportClub.Models;

namespace SportClub.Logic
{
	public class UserProvider : IUserProvider
	{
		private readonly IStorageProvider userProvider;
		public UserProvider(IStorageProvider userProvider)
		{
			this.userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
		}


		public List<User> GetUsers()
		{
			return userProvider.GetUsers();
		}

		public void AddUser(User user)
		{
			userProvider.AddUser(user);
		}
	}
}