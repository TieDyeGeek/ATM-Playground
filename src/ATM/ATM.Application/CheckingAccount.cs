﻿using System;
using System.Collections.Generic;
using System.Linq;
using ATM.Application.Repository;

namespace ATM.Application
{
	public class CheckingAccount
	{
		private readonly IAtmRepository _repository;
		private List<Transaction> TransactionHistory { get; }

		public CheckingAccount()//IAtmRepository repository)
		{
			//_repository = repository;
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

		public double Deposit(double amount, string description)
		{
			if (amount <=0 )
				throw new Exception("Cannot deposit amount <= 0");

			AddTransaction(amount, description);
			return Balance;
		}

		public double Withdraw(double amount, string description)
		{
			if (amount > Balance)
				throw new Exception("Cannot withdraw more than balance");

			if (amount <= 0)
				throw new Exception("Cannot withdraw amount <= 0");

			AddTransaction(-amount, description);
			return Balance;
		}

		public double TransferFunds(double amount, Guid account)
		{
			return Balance;
		}

		private void AddTransaction(double amount, string description)
		{
			var transaction = new Transaction()
			{
				Id = new Guid(),
				Amount = amount,
				Description = description,
				Date = DateTime.UtcNow
			};

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