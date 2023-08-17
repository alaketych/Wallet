using Wallet.Infrastucture.Data.Dto.Operation;

namespace Wallet.API.Models.Account.Response
{
	public class AccountDetailedResponse
	{
		public int Id { get; set; }

		public string AccountName { get; set; }

		public decimal Balance { get; set; }

		public decimal Limit { get; set; }

		public string PaymentDue { get; set; }

		public IList<OperationDto> Operations { get; set; }

		public string DailyPoints { get; set; }
	}
}
