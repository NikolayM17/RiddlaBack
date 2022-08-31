using DAL.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T>
		where T : BaseEntity
	{
		private readonly AppDbContext _db;

		public BaseRepository()
		{
			_db = new();
		}

		public BaseRepository(AppDbContext db)
		{
			_db = db;
		}

		public async Task AddAsync(T entity)
		{
			await _db.Set<T>().AddAsync(entity);
			await _db.SaveChangesAsync();
		}

		public async Task AddRangeAsync(IEnumerable<T> entities)
		{
			await _db.Set<T>().AddRangeAsync(entities);
			await _db.SaveChangesAsync();
		}

		public IQueryable<T> GetAll()
		{
			return _db.Set<T>();
		}

		public T Get(T entity)
		{
			return _db.Set<T>().First(e => e == entity);
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _db.Set<T>().FindAsync(id);
		}

		public async Task<T> UpdateAsync(T entity)
		{
			_db.Set<T>().Update(entity);
			await _db.SaveChangesAsync();

			return entity;
		}

		public async Task DeleteByIdAsync(int id)
		{
			/*var targetEntity = await GetById(id);

			_db.Set<T>().Remove(targetEntity);*/

			_db.Set<T>().Remove(await GetByIdAsync(id));
			await _db.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			_db.Set<T>().Remove(entity);
			await _db.SaveChangesAsync();
		}

		/*public void Dispose()
		{
			_db.Dispose();
		}*/
	}
}
