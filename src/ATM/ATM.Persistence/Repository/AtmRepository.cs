using ATM.Application.Repository;
using CSESoftware.Repository.EntityFrameworkCore;

namespace ATM.Persistence.Repository
{
	public class AtmRepository : Repository<DbContext>, IAtmRepository
	{
		public AtmRepository(DbContext context) : base(context)
		{
		}
	}
}
