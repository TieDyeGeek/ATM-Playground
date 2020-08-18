using ATM.Application;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Account = ATM.Persistence.Models.Account;

namespace ATM.Persistence
{
	public class CheckingAccountQueryBuilder : PersistenceQueryBuilder<Account, CheckingAccount>
	{
		public CheckingAccountQueryBuilder(DbContextOptions contextOptions, IMapper mapper) : base(contextOptions, mapper)
		{
		}
	}
}
