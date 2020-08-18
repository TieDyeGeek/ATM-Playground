using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ATM.Application.Persistence;
using ATM.Persistence.Repository;
using AutoMapper;
using CSESoftware.Repository;
using CSESoftware.Repository.Builder;
using CSESoftware.Repository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Transaction = ATM.Persistence.Models.Transaction;

namespace ATM.Persistence
{
	public class TransactionQueryBuilder : ITransactionQueryBuilder
	{
		private readonly IMapper _mapper;
		private readonly IReadOnlyRepository _repository;
		private readonly QueryBuilder<Transaction> _query;
		public TransactionQueryBuilder(DbContextOptions contextOptions, IMapper mapper)
		{
			_mapper = mapper;
			_repository = new Repository<AtmDbContext>(new AtmDbContext(contextOptions));
			_query = new QueryBuilder<Transaction>();
		}

		public ITransactionQueryBuilder Where(Expression<Func<Application.Transaction, bool>> expression)
		{
			_query.Where(expression);
			return this;
		}

		public ITransactionQueryBuilder OrderBy(Func<IQueryable<Application.Transaction>, IOrderedQueryable<Application.Transaction>> order)
		{
			_query.OrderBy(order);
			return this;
		}

		public ITransactionQueryBuilder Include(IEnumerable<Expression<Func<Application.Transaction, object>>> includes)
		{
			_query.Include(includes);
			return this;
		}

		public ITransactionQueryBuilder Include(Expression<Func<Application.Transaction, object>> include)
		{
			_query.Include(include);
			return this;
		}

		public ITransactionQueryBuilder Skip(int? skip)
		{
			_query.Skip(skip);
			return this;
		}

		public ITransactionQueryBuilder Take(int? take)
		{
			_query.Take(take);
			return this;
		}

		public ITransactionQueryBuilder WithThisCancellationTokenToken(CancellationToken token)
		{
			_query.WithThisCancellationTokenToken(token);
			return this;
		}

		public async Task<IEnumerable<Application.Transaction>> GetAll()
		{
			var accounts = await _repository.GetAllAsync(_query.Build());

			return accounts.Select(x => _mapper.Map<Transaction, Application.Transaction>(x));
		}

		public async Task<Application.Transaction> GetFirst()
		{
			var account = await _repository.GetFirstAsync(_query.Build());

			return _mapper.Map<Transaction, Application.Transaction>(account);
		}

		public async Task<bool> GetExists()
		{
			return await _repository.GetExistsAsync(_query.Build());
		}
	}
}
