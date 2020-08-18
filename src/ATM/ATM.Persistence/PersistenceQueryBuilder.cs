using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ATM.Application.Persistence;
using ATM.Persistence.Repository;
using AutoMapper;
using CSESoftware.Core.Entity;
using CSESoftware.Repository;
using CSESoftware.Repository.Builder;
using CSESoftware.Repository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ATM.Persistence
{
	public class PersistenceQueryBuilder<TDataModel, TApplicationModel> : IQueryBuilder<TApplicationModel> where TDataModel : class, IEntity
	{
		private readonly IMapper _mapper;
		private readonly IReadOnlyRepository _repository;
		private readonly QueryBuilder<TDataModel> _query;
		public PersistenceQueryBuilder(DbContextOptions contextOptions, IMapper mapper)
		{
			_mapper = mapper;
			_repository = new Repository<AtmDbContext>(new AtmDbContext(contextOptions));
			_query = new QueryBuilder<TDataModel>();
		}

		public IQueryBuilder<TApplicationModel> Where(Expression<Func<TApplicationModel, bool>> expression)
		{
			var dataExpression = _mapper.Map<Expression<Func<TDataModel, bool>>>(expression);
			_query.Where(dataExpression);
			return this;
		}

		public IQueryBuilder<TApplicationModel> OrderBy(Func<IQueryable<TApplicationModel>, IOrderedQueryable<TApplicationModel>> order)
		{
			var dataOrder = _mapper.Map<Func<IQueryable<TDataModel>, IOrderedQueryable<TDataModel>>>(order);
			_query.OrderBy(dataOrder);
			return this;
		}

		public IQueryBuilder<TApplicationModel> Include(Expression<Func<TApplicationModel, object>> include)
		{
			var dataInclude = _mapper.Map<Expression<Func<TDataModel, object>>>(include);
			_query.Include(dataInclude);
			return this;
		}

		public IQueryBuilder<TApplicationModel> Skip(int? skip)
		{
			_query.Skip(skip);
			return this;
		}

		public IQueryBuilder<TApplicationModel> Take(int? take)
		{
			_query.Take(take);
			return this;
		}

		public IQueryBuilder<TApplicationModel> WithThisCancellationTokenToken(CancellationToken token)
		{
			_query.WithThisCancellationTokenToken(token);
			return this;
		}

		public async Task<IEnumerable<TApplicationModel>> GetAll()
		{
			var accounts = await _repository.GetAllAsync(_query.Build());

			return accounts.Select(x => _mapper.Map<TDataModel, TApplicationModel>(x));
		}

		public async Task<TApplicationModel> GetFirst()
		{
			var account = await _repository.GetFirstAsync(_query.Build());

			return _mapper.Map<TDataModel, TApplicationModel>(account);
		}

		public async Task<bool> GetExists()
		{
			return await _repository.GetExistsAsync(_query.Build());
		}
	}
}
