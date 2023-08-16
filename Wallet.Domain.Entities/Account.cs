using Wallet.Domain.Interfaces;

namespace Wallet.Domain.Entities
{
	public class Account : IEntity
	{
		public int Id { get; set; }

		public string AccountName { get; set; }

		public decimal Balance { get; set; }

		public decimal Limit { get; set; }
	}
}
