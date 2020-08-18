using System;
using System.Threading.Tasks;
using ATM.Persistence.Repository;
using CSESoftware.Core.Entity;
using CSESoftware.Repository;
using CSESoftware.Repository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ATM.Persistence
{
	public class PersistenceRepository<TDataModel, TApplicationModel> where TDataModel : class, IEntityWithId<Guid>
	{
		protected readonly IRepository Repository;

		public PersistenceRepository(DbContextOptions contextOptions)
		{
			Repository = new Repository<AtmDbContext>(new AtmDbContext(contextOptions));
		}

		public virtual void Create(TApplicationModel entity)
		{
		}

		//public virtual Task Update(TApplicationModel entity)
		//{
		//}

		public void Delete(Guid id)
		{
			Repository.Delete<TDataModel, Guid>(id);
		}

		public async Task SaveAsync()
		{
			await Repository.SaveAsync();
		}
	}
}
