using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportClub.Enums;
using SportClub.Interfaces;
using SportClub.Models;

namespace SportClub.Controllers
{
	[Route("api/[controller]")]
	public class SampleDataController : Controller
	{
		private readonly IUserProvider userProvider;
		private readonly IAdminProvider adminProvider;
		private readonly ITrainerProvider trainerProvider;

		public SampleDataController(IUserProvider userProvider, IAdminProvider adminProvider, ITrainerProvider trainerProvider)
		{
			this.userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
			this.adminProvider = adminProvider ?? throw new ArgumentNullException(nameof(adminProvider));
			this.trainerProvider = trainerProvider ?? throw new ArgumentNullException(nameof(trainerProvider));
		}

		private static string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		[HttpGet("[action]")]
		public IEnumerable<User> Users()
		{
			return userProvider.GetUsers(); //userProvider.AddUser(new User{ Name = "Name1", Age = 19, NameClub = "Name club", RankClub = 1});
		}

		[HttpGet("[action]")]
		public IEnumerable<Trainer> TrainerMode()
		{
			var rng = new Random();
			
			return trainerProvider.GetTrainers();
		}

		public class WeatherForecast
		{
			public string DateFormatted { get; set; }
			public int TemperatureC { get; set; }
			public string Summary { get; set; }

			
			public int TemperatureF
			{
				get { return 32 + (int) (TemperatureC / 0.5556); }
			}
		}
	}
}