using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATM.Application.Tests
{
	[TestClass]
	public class CheckingAccountTests
	{
		private CheckingAccount GetCheckingAccount()
		{
			return new CheckingAccount();
		}

		[TestMethod]
		public void InitialBalanceTest()
		{
			var account = GetCheckingAccount();

			Assert.AreEqual(0, account.Balance);
		}

		[TestMethod]
		public void DepositTest()
		{
			var account = GetCheckingAccount();

			Assert.AreEqual(3.14, account.Deposit(3.14, "ATM on 3rd St."));
			Assert.AreEqual(140.14, account.Deposit(137, "ATM on 2rd St."));
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void NegativeDepositTest()
		{
			var account = GetCheckingAccount();

			account.Deposit(-3.14, "ATM on 3rd St.");
		}

		[TestMethod]
		public void WithdrawTest()
		{
			var account = GetCheckingAccount();
			account.Deposit(100, "test");

			Assert.AreEqual(40, account.Withdraw(60, "ATM on 3rd St."));
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void WithdrawGreaterThanBalanceTest()
		{
			var account = GetCheckingAccount();
			account.Deposit(15, "test");

			account.Withdraw(73, "ATM on 3rd St.");
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void WithdrawNegativeTest()
		{
			var account = GetCheckingAccount();

			account.Withdraw(-10, "ATM on 3rd St.");
		}
	}
}
