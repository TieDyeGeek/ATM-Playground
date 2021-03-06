﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM.Application.Persistence;

namespace ATM.Application
{
	public class SavingsAccount : Account	{
		public SavingsAccount(IRepository<Transaction, Guid> repository, IQueryBuilder<Transaction> queryBuilder) : base(repository, queryBuilder)
		{
		}

		public override async Task<double> Withdraw(double amount, string description)
		{
			if (amount > Balance)
				throw new Exception("Cannot withdraw more than balance");

			var amountWithdrawnInLast24Hours = GetLast24HoursOfTransactions().Where(x => x.Amount < 0).Sum(x => x.Amount) - amount;
			if (amountWithdrawnInLast24Hours <= -500)
				throw new Exception("Cannot withdraw more than $500 in a 24 hour period");

			return await base.Withdraw(amount, description);
		}

		private List<Transaction> GetLast24HoursOfTransactions()
		{
			return TransactionHistory.Where(x => x.Date >= DateTime.UtcNow.AddDays(-1)).ToList();
		}
	}
}
