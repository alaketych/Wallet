using Wallet.Infrastucture.Data.Repositories;

namespace Wallet.Infrastucture.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DataContext _context;

		public AccountRepository AccountRepository { get; }

		public OperationRepository OperationRepository { get; }

		public UnitOfWork(
			DataContext context,
			AccountRepository accountRepository,
			OperationRepository operationRepository)
		{
			_context = context;
			AccountRepository = accountRepository;
			OperationRepository = operationRepository;
		}

		public void Commit()
		{
			_context.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_context.Dispose();
			}
		}
	}
}
