using System;

namespace ATM.Application
{
	internal class Transaction
	{
		public Guid Id { get; set; }
		public string Description { get; set; }
		public double Amount { get; set; }
		public DateTime Date { get; set; }
	}
}
