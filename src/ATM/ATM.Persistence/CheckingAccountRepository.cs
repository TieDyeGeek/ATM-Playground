using System;
using System.Threading.Tasks;
using ATM.Application;
using ATM.Persistence.Models;
using ATM.Persistence.Repository;
using CSESoftware.Repository;
using CSESoftware.Repository.Builder;
using CSESoftware.Repository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Account = ATM.Persistence.Models.Account;

namespace ATM.Persistence
{
	public class CheckingAccountRepository
	{
		private readonly IRepository _repository;

		public CheckingAccountRepository(DbContextOptions contextOptions)
		{
			_repository = new Repository<AtmDbContext>(new AtmDbContext(contextOptions));
		}

		public void Create(CheckingAccount account)
		{
			_repository.Create(new Account
			{
				Id = account.Id,
				HolderId = account.HolderId,
				Name = account.Name,
				Type = AccountType.Checking
			});
		}

		public async Task Update(CheckingAccount account)
		{
			var entity = await _repository.GetFirstAsync(
				new QueryBuilder<Account>()
				.WithId(account.Id)
				.Build());

			entity.HolderId = account.HolderId;
			entity.Name = account.Name;

			_repository.Update(entity);
		}

		public void Delete(Guid id)
		{
			_repository.Delete<Account, Guid>(id);
		}

		public async  Task SaveAsync()
		{
			await _repository.SaveAsync();
		}
	}
}
