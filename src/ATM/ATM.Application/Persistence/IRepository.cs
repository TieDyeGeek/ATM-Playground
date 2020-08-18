using System;
using System.Threading.Tasks;

namespace ATM.Application.Persistence
{
	public interface IRepository<in T, in TId>
	{
		void Create(T entity);
		void Delete(TId id);
		Task SaveAsync();
	}
}