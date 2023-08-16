using Wallet.Domain.Interfaces;

namespace Wallet.Infrastucture.Data.Dto.Account
{
	public class AccountDto : IEntity
	{
		public int Id { get; set; }

		public string AccountName { get; set; }

		public decimal Balance { get; set; }

		public decimal Limit { get; set; }
	}
}
