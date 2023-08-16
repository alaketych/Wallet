using Wallet.Infrastucture.Data.Repositories;

namespace Wallet.Infrastucture.Data
{
	public interface IUnitOfWork : IDisposable
	{
		AccountRepository AccountRepository { get; }

		OperationRepository OperationRepository { get; }

		void Commit();
	}
}
