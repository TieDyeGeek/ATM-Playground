using CSESoftware.Core.Entity;

namespace ATM.Persistence.Models
{
	public class Holder : BaseEntity<int>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string Username { get; set; }
		public string Password { get; set; }
	}
}
