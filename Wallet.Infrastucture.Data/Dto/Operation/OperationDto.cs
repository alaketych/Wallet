using Wallet.Domain.Entities;
using Wallet.Domain.Interfaces;

namespace Wallet.Infrastucture.Data.Dto.Operation
{
	public class OperationDto : IEntity
	{
		public int Id { get; set; }

		public int AccountId { get; set; }

		public OperationType Type { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTimeOffset DateTimeOffset { get; set; }

		public bool Pending { get; set; }

		public decimal Total { get; set; }

		public byte[] Icon { get; set; }
	}
}
