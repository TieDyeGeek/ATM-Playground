using System;
using System.Threading.Tasks;

namespace ATM.Application.Persistence
{
	public interface ITransactionRepository
	{
		void Create(Application.Transaction entity);
		void Delete(Guid id);
		Task SaveAsync();
	}
}