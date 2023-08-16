using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wallet.Domain.Interfaces
{
	public interface IRepository<T> where T : class, IEntity
	{
		Task<IList<T>> GetAllAsync(int offset, int limit);

		Task<T> GetIdAsync(int id);

		Task<T> AddAsync(T id);

		Task<T> UpdateAsync(T id);

		Task<bool> DeleteAsync(int id);
	}
}
