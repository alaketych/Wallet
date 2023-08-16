using Wallet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Wallet.Infrastucture.Data
{
	public class DataContext : DbContext
	{
		public DataContext()
		{

		}

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
			modelBuilder.Seed();
		}
	}
}
