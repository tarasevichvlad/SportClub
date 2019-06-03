using System.ComponentModel.DataAnnotations;

namespace SportClub.Models
{
	public class Trainer
	{
		[Key] public int ID { get; set; }
		public string Name { get; set; }
		public int Rank { get; set; }
	}
}