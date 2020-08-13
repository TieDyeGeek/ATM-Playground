using System;

namespace ATM.Application
{
	internal class Transaction
	{
		public Transaction(Guid accountId, double amount, string description)
		{
			Id = new Guid();
			AccountId = accountId;
			Amount = amount;
			Description = description;
			Date = DateTime.UtcNow;
		}

		public Guid Id { get; }
		public Guid AccountId { get; }
		public string Description { get; }
		public double Amount { get; }
		public DateTime Date { get;  }
	}
}
