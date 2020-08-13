using ATM.Application.Repository;
using CSESoftware.Repository.EntityFrameworkCore;

namespace ATM.Persistence.Repository
{
	public class AtmRepository : Repository<AtmDbContext>, IAtmRepository
	{
		public AtmRepository(AtmDbContext context) : base(context)
		{
		}
	}
}
