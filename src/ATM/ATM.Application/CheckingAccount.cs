using System;
using System.Collections.Generic;

namespace ATM.Application
{
	public class CheckingAccount
	{
		public Guid Id { get; }
		public double Balance { get; }
		public List<Transaction> TransactionHistory { get; }
	}
}
