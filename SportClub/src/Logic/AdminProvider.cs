using System;
using System.Collections.Generic;
using SportClub.Interfaces;
using SportClub.Models;

namespace SportClub.Logic
{
	public class AdminProvider : IAdminProvider
	{
		private readonly IStorageProvider adminProvider;
		public AdminProvider(IStorageProvider adminProvider)
		{
			this.adminProvider = adminProvider ?? throw new ArgumentNullException(nameof(adminProvider));
		}

		public List<User> GetUsers()
		{
			return adminProvider.GetUsers();
		}

		public void AddUser(User user)
		{
			adminProvider.AddUser(user);
		}

		public void UpdateUser(User user)
		{
			adminProvider.UpdateUser(user);
		}

		public List<Trainer> GetTrainers()
		{
			return adminProvider.GetTrainers();
		}

		public void AddTrainer(Trainer trainer)
		{
			adminProvider.AddTrainer(trainer);
		}

		public void UpdateTrainer(Trainer trainer)
		{
			adminProvider.UpdateTrainer(trainer);
		}

		public void DeleteTrainer(Trainer trainer)
		{
			adminProvider.DeleteTrainer(trainer);
		}
	}
}