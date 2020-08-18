using System;
using ATM.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace ATM.Application.Tests.Helpers
{
	internal static class DatabaseMock
	{
		internal static DbContextOptions<AtmDbContext> GetOptions()
		{
			return new DbContextOptionsBuilder<AtmDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
		}
	}
}
