using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM.Application
{
	public abstract class Account
	{
		internal List<Transaction> TransactionHistory { get; }
		protected Account()
		{
			TransactionHistory = new List<Transaction>();
		}
		public Guid Id { get; }

		public double Balance
		{
			get
			{
				return TransactionHistory.Sum(x => x.Amount);
			}
		}

		public virtual double Deposit(double amount, string description)
		{
			if (amount <= 0)
				throw new Exception("Cannot deposit amount <= 0");

			AddTransaction(amount, description);
			return Balance;
		}

		public virtual double Withdraw(double amount, string description)
		{
			if (amount <= 0)
				throw new Exception("Cannot withdraw amount <= 0");

			AddTransaction(-amount, description);
			return Balance;
		}

		public virtual double TransferFunds(double amount, Guid account)
		{
			return Balance;
		}

		private void AddTransaction(double amount, string description)
		{
			var transaction = new Transaction(Id, amount, description);

			TransactionHistory.Add(transaction);

			//_repository.Create(new Persistence.Models.Transaction()
			//{
			//	Id = transaction.Id,
			//	AccountId = Id,
			//	Amount = transaction.Amount,
			//	Date = transaction.Date,
			//	Description = transaction.Description
			//});
			//
			//_repository.SaveAsync();
		}
	}
}
