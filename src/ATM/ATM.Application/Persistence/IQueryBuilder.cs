using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ATM.Application.Persistence
{
	public interface IQueryBuilder<T>
	{
		IQueryBuilder<T> Where(Expression<Func<T, bool>> expression);
		IQueryBuilder<T> OrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> order);
		IQueryBuilder<T> Include(Expression<Func<T, object>> include);
		IQueryBuilder<T> Skip(int? skip);
		IQueryBuilder<T> Take(int? take);
		IQueryBuilder<T> WithThisCancellationTokenToken(CancellationToken token);
		Task<IEnumerable<T>> GetAll();
		Task<T> GetFirst();
		Task<bool> GetExists();
	}
}