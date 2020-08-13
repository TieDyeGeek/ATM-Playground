using System;
using System.Threading.Tasks;
using ATM.Application.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATM.Application.Tests
{
	[TestClass]
	public class CheckingAccountTests
	{
		private CheckingAccount GetCheckingAccount()
		{
			return new CheckingAccount(DatabaseMock.GetProjectRepository(DatabaseMock.GetOptions()));
		}

		[TestMethod]
		public void InitialBalanceTest()
		{
			var account = GetCheckingAccount();

			Assert.AreEqual(0, account.Balance);
		}

		[TestMethod]
		public async Task DepositTest()
		{
			var account = GetCheckingAccount();

			Assert.AreEqual(3.14, await account.Deposit(3.14, "ATM on 3rd St."));
			Assert.AreEqual(140.14, await account.Deposit(137, "ATM on 2rd St."));
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public async Task NegativeDepositTest()
		{
			var account = GetCheckingAccount();

			await account.Deposit(-3.14, "ATM on 3rd St.");
		}

		[TestMethod]
		public async Task WithdrawTest()
		{
			var account = GetCheckingAccount();
			await account.Deposit(100, "test");

			Assert.AreEqual(40, await account.Withdraw(60, "ATM on 3rd St."));
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public async Task WithdrawGreaterThanBalanceTest()
		{
			var account = GetCheckingAccount();
			await account.Deposit(15, "test");

			await account.Withdraw(73, "ATM on 3rd St.");
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public async Task WithdrawNegativeTest()
		{
			var account = GetCheckingAccount();

			await account.Withdraw(-10, "ATM on 3rd St.");
		}
	}
}
