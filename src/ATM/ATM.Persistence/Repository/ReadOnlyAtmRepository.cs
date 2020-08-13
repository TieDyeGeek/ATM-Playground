using ATM.Application.Repository;
using CSESoftware.Repository.EntityFrameworkCore;

namespace ATM.Persistence.Repository
{
	public class ReadOnlyAtmRepository : ReadOnlyRepository<AtmDbContext>, IReadOnlyAtmRepository
	{
		public ReadOnlyAtmRepository(AtmDbContext context) : base(context)
		{
		}
	}
}
