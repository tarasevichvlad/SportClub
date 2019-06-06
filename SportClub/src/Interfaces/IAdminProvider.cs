using SportClub.Models;

namespace SportClub.Interfaces
{
	public interface IAdminProvider : IUserProvider, ITrainerProvider
	{
		void UpdateUser(User user);
		void DeleteUser(User uset);
	}
}