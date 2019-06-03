using System;
using System.Collections.Generic;
using SportClub.Interfaces;
using SportClub.Models;

namespace SportClub.Logic
{
	public class TrainerProvider : ITrainerProvider
	{
		private readonly IStorageProvider trainerProvider;
		public TrainerProvider(IStorageProvider trainerProvider)
		{
			this.trainerProvider = trainerProvider ?? throw new ArgumentNullException(nameof(trainerProvider));
		}

		public List<Trainer> GetTrainers()
		{
			return trainerProvider.GetTrainers();
		}

		public void AddTrainer(Trainer trainer)
		{
			trainerProvider.AddTrainer(trainer);
		}

		public void UpdateTrainer(Trainer trainer)
		{
			trainerProvider.UpdateTrainer(trainer);
		}
	}
}