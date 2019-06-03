using System.Collections.Generic;
using SportClub.Models;

namespace SportClub.Interfaces
{
	public interface ITrainerProvider
	{
		List<Trainer> GetTrainers();

		void AddTrainer(Trainer trainer);

		void UpdateTrainer(Trainer trainer);
	}
}