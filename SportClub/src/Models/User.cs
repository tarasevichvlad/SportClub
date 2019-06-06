using System.ComponentModel.DataAnnotations;

namespace SportClub.Models
{
	public class User
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public string NameClub { get; set; }
		public int RankClub { get; set; }
	}
}