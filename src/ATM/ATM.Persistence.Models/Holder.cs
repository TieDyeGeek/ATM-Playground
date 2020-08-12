﻿using CSESoftware.Core.Entity;

namespace ATM.Persistence.Models
{
	public class Holder : BaseEntity<int>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }

		public string Username { get; set; }
		public string Password { get; set; }
	}
}
