using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM.Application.Repository;

namespace ATM.Application
{
	public abstract class Account
	{
		internal List<Transaction> TransactionHistory { get; }
		private readonly IAtmRepository _repository;

		protected Account(IAtmRepository repository)
		{
			TransactionHistory = new List<Transaction>();
			_repository = repository;
		}

		public Guid Id { get; }

		public double Balance
		{
			get
			{
				return TransactionHistory.Sum(x => x.Amount);
			}
		}

		public virtual async Task<double> Deposit(double amount, string description)
		{
			if (amount <= 0)
				throw new Exception("Cannot deposit amount <= 0");

			await AddTransaction(amount, description);
			return Balance;
		}

		public virtual async Task<double> Withdraw(double amount, string description)
		{
			if (amount <= 0)
				throw new Exception("Cannot withdraw amount <= 0");

			await AddTransaction(-amount, description);
			return Balance;
		}

		public virtual double TransferFunds(double amount, Guid account)
		{
			return Balance;
		}

		private async Task AddTransaction(double amount, string description)
		{
			var transaction = new Transaction(Id, amount, description);

			TransactionHistory.Add(transaction);

			_repository.Create(new Persistence.Models.Transaction()
			{
				Id = transaction.Id,
				AccountId = Id,
				Amount = transaction.Amount,
				Date = transaction.Date,
				Description = transaction.Description
			});

			await _repository.SaveAsync();
		}
	}
}
