using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Entities;

namespace Wallet.Infrastucture.Data.Configuration
{
	public class OperationConfiguration : IEntityTypeConfiguration<Operation>
	{
		public void Configure(EntityTypeBuilder<Operation> entity)
		{
			entity
				.HasKey(x => x.Id);

			entity
				.Property(x => x.Type)
				.IsRequired();

			//entity
			//	.HasOne(x => x.Account)
			//	.WithOne(x => x.Id)

			entity
				.Property(x => x.Name)
				.HasMaxLength(100)
				.IsRequired();

			entity
				.Property(x => x.Description)
				.HasMaxLength(1000)
				.IsRequired();

			entity
				.Property(x => x.DateTimeOffset)
				.IsRequired();

			entity
				.Property(x => x.Pending);

			entity
				.Property(x => x.Total)
				.HasPrecision(18, 2)
				.IsRequired();

			entity
				.Property(x => x.Icon);
		}
	}
}
