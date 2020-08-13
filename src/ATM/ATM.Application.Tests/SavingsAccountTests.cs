using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATM.Application.Tests
{
	[TestClass]
	public class SavingsAccountTests
	{
		private SavingsAccount GetSavingsAccount()
		{
			return new SavingsAccount();
		}

		[TestMethod]
		public void InitialBalanceTest()
		{
			var account = GetSavingsAccount();

			Assert.AreEqual(0, account.Balance);
		}

		[TestMethod]
		public void DepositTest()
		{
			var account = GetSavingsAccount();

			Assert.AreEqual(3.14, account.Deposit(3.14, "Branch on 3rd St."));
			Assert.AreEqual(140.14, account.Deposit(137, "Branch on 2rd St."));
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void NegativeDepositTest()
		{
			var account = GetSavingsAccount();

			account.Deposit(-3.14, "Branch on 3rd St.");
		}

		[TestMethod]
		public void WithdrawTest()
		{
			var account = GetSavingsAccount();
			account.Deposit(100, "test");

			Assert.AreEqual(40, account.Withdraw(60, "Branch on 3rd St."));
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void WithdrawGreaterThanBalanceTest()
		{
			var account = GetSavingsAccount();
			account.Deposit(15, "test");

			account.Withdraw(73, "Branch on 3rd St.");
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void WithdrawNegativeTest()
		{
			var account = GetSavingsAccount();

			account.Withdraw(-10, "Branch on 3rd St.");
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void WithdrawTooMuchIn24HoursInOneLargeTransactionTest()
		{
			var account = GetSavingsAccount();
			account.Deposit(1000, "Initial deposit");

			account.Withdraw(500.01, "Large Withdraw");
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void WithdrawTooMuchIn24HoursInSmallerTransactionsTest()
		{
			var account = GetSavingsAccount();
			account.Deposit(1000, "Initial deposit");

			account.Withdraw(499, "Almost large withdraw");
			account.Withdraw(1, "Small withdraw");
			account.Withdraw(0.01, "Penny withdraw");
		}
	}
}
