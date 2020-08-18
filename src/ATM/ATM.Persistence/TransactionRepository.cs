using ATM.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace ATM.Persistence
{
	public class TransactionRepository :
		PersistenceRepository<Transaction, Application.Transaction>
	{
		public TransactionRepository(DbContextOptions contextOptions) : base(contextOptions)
		{
		}

		public override void Create(Application.Transaction entity)
		{
			Repository.Create(new Transaction
			{
				Id = entity.Id,
				AccountId = entity.AccountId,
				Amount = entity.Amount,
				Description = entity.Description,
				Date = entity.Date
			});
		}
	}
}
