﻿using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
		/*new void Dispose();*/
	}
}
