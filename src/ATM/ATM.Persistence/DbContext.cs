using ATM.Persistence.Models;
using CSESoftware.Repository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ATM.Persistence
{
	public class DbContext : BaseDbContext
	{
		public DbContext(DbContextOptions options) : base(options)
		{
		}

		public virtual DbSet<Holder> Holders { get; set; }
		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<Transaction> Transactions { get; set; }
	}
}
