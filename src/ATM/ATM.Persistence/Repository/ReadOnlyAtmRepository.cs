using ATM.Application.Repository;
using CSESoftware.Repository.EntityFrameworkCore;

namespace ATM.Persistence.Repository
{
	public class ReadOnlyAtmRepository : ReadOnlyRepository<DbContext>, IReadOnlyAtmRepository
	{
		public ReadOnlyAtmRepository(DbContext context) : base(context)
		{
		}
	}
}
