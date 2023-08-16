using Microsoft.EntityFrameworkCore;
using Wallet.Domain.Entities;

namespace Wallet.Infrastucture.Data
{
	public static class ModelBuilderExtension
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>()
				.HasData(
					new Account
					{
						Id = 1,
						AccountName = "Test",
						Balance = 13,
					});

			modelBuilder.Entity<Operation>()
				.HasData(
					new Operation
					{ 
						Id = 1,
						AccountId = 1,
						Type = OperationType.Credit,
						Name = "Test",
						Description = "Test",
						DateTimeOffset = DateTimeOffset.UtcNow,
						Pending = false,
						Total = 5,
						Icon = new byte[] { }
					}
				);
		}
	}
}
