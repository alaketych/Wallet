using Microsoft.EntityFrameworkCore;
using Wallet.Domain.Entities;

namespace Wallet.Infrastucture.Data.Repositories
{
	public class OperationRepository : Repository<Operation, DataContext>
	{
		private readonly DataContext _context;

		public OperationRepository(DataContext context) : base(context)
		{
			context = _context;
		}

		public async Task<IList<Operation>> GetLatestOperations(int id)
		{
			int latestOperations = 10;

			return await _context.Set<Operation>()
				.Where(acc => acc.AccountId == id)
				.OrderBy(o => o.DateTimeOffset)
				.Take(latestOperations)
				.ToListAsync();
		}
	}
}
