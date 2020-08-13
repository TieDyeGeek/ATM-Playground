using System;

namespace ATM.Application
{
	public class CheckingAccount : Account
	{
		public override double Withdraw(double amount, string description)
		{
			if (amount > Balance)
				throw new Exception("Cannot withdraw more than balance");

			return base.Withdraw(amount, description);
		}
	}
}
