using System.Collections.Generic;

namespace SportClub.Interfaces
{
	public interface IStorageProvider : IAdminProvider, IUserProvider, ITrainerProvider
	{
	}
}