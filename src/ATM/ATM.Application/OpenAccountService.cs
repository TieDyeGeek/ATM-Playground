using System;
using System.Linq;
using System.Threading.Tasks;
using ATM.Application.Repository;
using ATM.Persistence.Models;
using AutoMapper;
using CSESoftware.Repository.Builder;

namespace ATM.Application
{
	public class OpenAccountService
	{
		private readonly IAtmRepository _repository;
		private readonly IMapper _mapper;

		public OpenAccountService(IAtmRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<CheckingAccount> CreateCheckingAccount(int holderId, string accountName)
		{
			var account = await CreateAccount(holderId, accountName, AccountType.Checking);

			return _mapper.Map<Persistence.Models.Account, CheckingAccount>(account);
		}

		public async Task<CheckingAccount> CreateSavingsAccount(int holderId, string accountName)
		{
			var account = await CreateAccount(holderId, accountName, AccountType.Savings);

			return _mapper.Map<Persistence.Models.Account, CheckingAccount>(account);
		}

		public async Task<CheckingAccount> CreateHomeEquityLineOfCreditAccount(int holderId, string accountName)
		{
			var account = await CreateAccount(holderId, accountName, AccountType.HomeEquityLineOfCredit);

			return _mapper.Map<Persistence.Models.Account, CheckingAccount>(account);
		}

		private async Task<Persistence.Models.Account> CreateAccount(int holderId, string accountName, AccountType accountType)
		{
			if (string.IsNullOrWhiteSpace(accountName))
				throw new Exception("Account name cannot be empty");

			var currentAccountsForHolder = await _repository.GetAllAsync(
				new QueryBuilder<Persistence.Models.Account>()
					.Where(x => x.HolderId == holderId)
					.Build());

			if (currentAccountsForHolder.Any(x => x.Name.Equals(accountName, StringComparison.OrdinalIgnoreCase)))
				throw new Exception("Account name already exists");

			if (currentAccountsForHolder.Any(x => x.Type == accountType && x.IsActive))
				throw new Exception($"Account Holder already has an account of this type ({accountType})");

			var account = new Persistence.Models.Account()
			{
				Id = new Guid(),
				HolderId = holderId,
				Name = accountName,
				Type = accountType
			};

			_repository.Create(account);
			await _repository.SaveAsync();

			return account;
		}
	}
}
