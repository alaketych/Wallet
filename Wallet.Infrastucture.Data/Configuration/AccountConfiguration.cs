using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Entities;

namespace Wallet.Infrastucture.Data.Configuration
{
	public class AccountConfiguration : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> entity)
		{ 
			entity
				.HasKey(x => x.Id);

			entity
				.Property(x => x.AccountName)
				.HasMaxLength(100)
				.IsRequired();

			entity
				.Property(x => x.Balance)
				.HasPrecision(18, 2)
				.IsRequired();

			entity
				.Property(x => x.Limit)
				.HasPrecision(18, 2)
				.HasDefaultValue(1500)
				.IsRequired();
		}
	}
}
