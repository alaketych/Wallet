using Wallet.Infrastucture.Data.Dto.Operation;

namespace Wallet.Services.Interfaces
{
	public interface IOperationService : IService<OperationDto>
	{
		Task<IList<OperationDto>> GetLatestAccountOperations(int id);
	}
}
