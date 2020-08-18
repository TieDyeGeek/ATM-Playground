using System;
using CSESoftware.Core.Entity;

namespace ATM.Persistence.Models
{
	public class Transaction : EntityWithId<Guid>
	{
		public string Description { get; set; }
		public double Amount { get; set; }
		public DateTime Date { get; set; }

		public Guid AccountId { get; set; }
		public Account Account { get; set; }
	}
}
