using Domain.Entities;

namespace DAL.Interfaces
{
	public interface IBaseRepository<T>/* : IDisposable*/
		where T : BaseEntity
	{
		Task AddAsync(T entity);
		Task AddRangeAsync(IEnumerable<T> entities);
		T Get(T entity);
		Task<T> GetByIdAsync(int id);
		IQueryable<T> GetAll();
		/*Task<T> GetByName(string name);*/
		Task<T> UpdateAsync(T entity);
		Task DeleteByIdAsync(int id);
		Task DeleteAsync(T entity);
		Task FillPrimaryDataAsync();

		/*new void Dispose();*/
	}
}
