using System.Collections.Generic;
using SportClub.Models;

namespace SportClub.Interfaces
{
	public interface IUserProvider
	{
		List<User> GetUsers();
		
		void AddUser(User user);
	}
}