using Wallet.Domain.Entities;
using Wallet.Domain.Interfaces;

namespace Wallet.Infrastucture.Data.Repositories
{
	public class AccountRepository : Repository<Account, DataContext>
	{
		private readonly DataContext _context;

		public AccountRepository(DataContext context) : base(context) 
		{
			context = _context;
		}
	}
}
