using Wallet.Domain.Entities;

namespace Wallet.API.Models.Operation.Response
{
	public class OperationDetailedResponse
	{
		public int Id { get; set; }

		public int AccountId { get; set; }

		public OperationType Type { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTimeOffset DateTimeOffset { get; set; }

		public bool Pending { get; set; }

		public string Status {get; set; }

		public decimal Total { get; set; }

		public byte[] Icon { get; set; }
	}
}
