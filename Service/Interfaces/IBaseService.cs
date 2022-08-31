using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
	public interface IBaseService<T>/* : IDisposable*/
		where T : BaseEntity
	{
		Task<BaseResponse<T>> AddEntityAsync(T entity);
		Task<BaseResponse<bool>> AddEntityRangeAsync(IEnumerable<T> entites);
		Task<BaseResponse<T>> GetEntityByIdAsync(int id);
		BaseResponse<T> GetEntityAsync(T entity);
		BaseResponse<IQueryable<T>> GetAllEntities();
		Task<BaseResponse<T>> UpdateEntityAsync(T entity);
		Task<BaseResponse<bool>> DeleteEntityAsync(T entity);
		Task<BaseResponse<bool>> DeleteEntityByIdAsync(int id);
		/*new void Dispose();*/
	}
}
