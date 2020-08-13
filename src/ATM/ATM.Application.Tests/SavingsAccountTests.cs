using System;
using System.Threading.Tasks;
using ATM.Application.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATM.Application.Tests
{
	[TestClass]
	public class SavingsAccountTests
	{
		private SavingsAccount GetSavingsAccount()
		{
			return new SavingsAccount(DatabaseMock.GetProjectRepository(DatabaseMock.GetOptions()));
		}

		[TestMethod]
		public void InitialBalanceTest()
		{
			var account = GetSavingsAccount();

			Assert.AreEqual(0, account.Balance);
		}

		[TestMethod]
		public async Task DepositTest()
		{
			var account = GetSavingsAccount();

			Assert.AreEqual(3.14, await account.Deposit(3.14, "Branch on 3rd St."));
			Assert.AreEqual(140.14, await account.Deposit(137, "Branch on 2rd St."));
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public async Task NegativeDepositTest()
		{
			var account = GetSavingsAccount();

			await account.Deposit(-3.14, "Branch on 3rd St.");
		}

		[TestMethod]
		public async Task WithdrawTest()
		{
			var account = GetSavingsAccount();
			await account.Deposit(100, "test");

			Assert.AreEqual(40, await account.Withdraw(60, "Branch on 3rd St."));
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public async Task WithdrawGreaterThanBalanceTest()
		{
			var account = GetSavingsAccount();
			await account.Deposit(15, "test");

			await account.Withdraw(73, "Branch on 3rd St.");
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public async Task WithdrawNegativeTest()
		{
			var account = GetSavingsAccount();

			await account.Withdraw(-10, "Branch on 3rd St.");
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public async Task WithdrawTooMuchIn24HoursInOneLargeTransactionTest()
		{
			var account = GetSavingsAccount();
			await account.Deposit(1000, "Initial deposit");

			await account.Withdraw(500.01, "Large Withdraw");
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public async Task WithdrawTooMuchIn24HoursInSmallerTransactionsTest()
		{
			var account = GetSavingsAccount();
			await account.Deposit(1000, "Initial deposit");

			await account.Withdraw(499, "Almost large withdraw");
			await account.Withdraw(1, "Small withdraw");
			await account.Withdraw(0.01, "Penny withdraw");
		}
	}
}
