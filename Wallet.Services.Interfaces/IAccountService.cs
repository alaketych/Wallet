using Wallet.Infrastucture.Data.Dto.Account;

namespace Wallet.Services.Interfaces
{
	public interface IAccountService : IService<AccountDto>
	{
		Task<short> GetDailyPoints(int id);
	}
}
