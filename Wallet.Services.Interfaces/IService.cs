using System.Threading.Tasks;
using System.Collections.Generic;
using Wallet.Domain.Interfaces;
using Wallet.Infrastucture.Data.Dto;

namespace Wallet.Services.Interfaces
{
	public interface IService<T> where T : class, IEntity
	{
		Task<IList<T>> GetAllAsync(FilterDto filter);

		Task<T> GetByIdAsync(int id);
	}
}
