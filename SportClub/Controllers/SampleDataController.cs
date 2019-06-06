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
			return userProvider.GetUsers();
		}
		
		[HttpGet("[action]")]
		public IEnumerable<Trainer> Trainers()
		{
			return trainerProvider.GetTrainers();
		}

		[HttpPost("[action]")]
		public IActionResult  AddUser([FromBody]User user)
		{
			userProvider.AddUser(user);
			return Ok(user);
		}
		
		[HttpPost("[action]")]
		public IActionResult  AddTrainer([FromBody]Trainer trainer)
		{
			trainerProvider.AddTrainer(trainer);
			return Ok(trainer);
		}
	
		[HttpPost("[action]")]
		public IActionResult  DeleteTrainer([FromBody]Trainer trainer)
		{
			trainerProvider.DeleteTrainer(trainer);
			return Ok(trainer);
		}
		
		[HttpPost("[action]")]
		public IActionResult  DeleteUser([FromBody]User user)
		{
			adminProvider.DeleteUser(user);
			return Ok(user);
		}
	}
}