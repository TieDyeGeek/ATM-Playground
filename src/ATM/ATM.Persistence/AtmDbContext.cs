using ATM.Persistence.Models;
using CSESoftware.Repository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ATM.Persistence
{
	public class AtmDbContext : BaseDbContext
	{
		public AtmDbContext(DbContextOptions options) : base(options)
		{
		}

		public virtual DbSet<Holder> Holders { get; set; }
		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<Transaction> Transactions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AtmDbContext).Assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
