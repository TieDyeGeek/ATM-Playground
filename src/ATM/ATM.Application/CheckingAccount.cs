using System;
using System.Threading.Tasks;
using ATM.Application.Repository;

namespace ATM.Application
{
	public class CheckingAccount : Account
	{
		public CheckingAccount(IAtmRepository repository) : base(repository)
		{
		}

		public override async Task<double> Withdraw(double amount, string description)
		{
			if (amount > Balance)
				throw new Exception("Cannot withdraw more than balance");

			return await base.Withdraw(amount, description);
		}
	}
}
