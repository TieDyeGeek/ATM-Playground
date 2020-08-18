using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM.Application.Persistence;

namespace ATM.Application
{
	public abstract class Account
	{
		internal List<Transaction> TransactionHistory { get; }
		private readonly IRepository<Transaction, Guid> _repository;

		protected Account(IRepository<Transaction, Guid> repository, IQueryBuilder<Transaction> queryBuilder)
		{
			_repository = repository;
			TransactionHistory = queryBuilder.Where(x => x.AccountId.Equals(Id)).GetAll().Result.ToList();
		}

		public Guid Id { get; }
		public Guid HolderId { get; }
		public string Name { get; }

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

			_repository.Create(transaction);

			await _repository.SaveAsync();
		}
	}
}
