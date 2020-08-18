using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ATM.Application.Persistence
{
	public interface ITransactionQueryBuilder
	{
		ITransactionQueryBuilder Where(Expression<Func<Transaction, bool>> expression);
		ITransactionQueryBuilder OrderBy(Func<IQueryable<Transaction>, IOrderedQueryable<Transaction>> order);
		ITransactionQueryBuilder Include(IEnumerable<Expression<Func<Transaction, object>>> includes);
		ITransactionQueryBuilder Include(Expression<Func<Transaction, object>> include);
		ITransactionQueryBuilder Skip(int? skip);
		ITransactionQueryBuilder Take(int? take);
		ITransactionQueryBuilder WithThisCancellationTokenToken(CancellationToken token);
		Task<IEnumerable<Application.Transaction>> GetAll();
		Task<Application.Transaction> GetFirst();
		Task<bool> GetExists();
	}
}