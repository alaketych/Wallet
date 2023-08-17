using Wallet.Infrastucture.Data.Dto.Account;
using Wallet.Infrastucture.Data.Dto.Operation;

namespace Wallet.Services.Interfaces
{
	public interface IAccountService : IService<AccountDto>
	{
		Task<string> GetPaymentDue();

		Task<string> GetDailyPoints(int id);

		Task<IList<OperationDto>> GetLatestOperation(int id);
	}
}
