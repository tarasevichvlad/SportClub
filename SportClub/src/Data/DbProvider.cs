using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportClub.Interfaces;
using SportClub.Models;

namespace SportClub.Data
{
	public class DbProvider : DbContext, IStorageProvider
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Trainer> Trainers { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=SportClub.db");
		}

		public void UpdateUser(User user)
		{
			Users.Update(user);
			SaveChanges();
		}

		public void DeleteUser(User user)
		{
			var removeUser = Trainers.Find(user.ID);
			Trainers.Remove(removeUser);
			SaveChanges();
		}

		public List<Trainer> GetTrainers()
		{
			return Trainers.ToList();
		}

		public void AddTrainer(Trainer trainer)
		{
			Trainers.Add(trainer);
			SaveChanges();
		}

		public void UpdateTrainer(Trainer trainer)
		{
			Trainers.Update(trainer);
			SaveChanges();
		}

		public void DeleteTrainer(Trainer trainer)
		{
			var removeTrainer = Trainers.Find(trainer.ID);
			Trainers.Remove(removeTrainer);
			SaveChanges();
		}

		public List<User> GetUsers()
		{
			return Users.ToList();
		}

		public void AddUser(User user)
		{
			Users.Add(user);
			SaveChanges();
		}
	}
}