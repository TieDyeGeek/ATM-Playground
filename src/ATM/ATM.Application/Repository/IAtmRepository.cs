using CSESoftware.Repository;

namespace ATM.Application.Repository
{
	public interface IAtmRepository : IRepository, IReadOnlyAtmRepository
	{
	}
}
