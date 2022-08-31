using DAL.Interfaces;
using DAL.Repositories;
using Domain.Entities;
using Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
	public class BaseService<T> : IBaseService<T>
		where T : BaseEntity
	{
		private readonly IBaseRepository<T> _repository;

		public BaseService()
		{
			_repository = new BaseRepository<T>();
		}

		public BaseService(IBaseRepository<T> repository)
		{
			_repository = repository;
		}

		/*public async Task<BaseResponse<T>> CreateEntity(T user)
		{
			try
			{
				await _repository.Create(user);

				return new BaseResponse<T>
				{
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = user
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<T>
				{
					Description = $"CreateUser Failed\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.InternalServerError,
					Data = user
				};
			}
		}*/

		public async Task<BaseResponse<T>> AddEntityAsync(T entity)
		{
			try
			{
				await _repository.AddAsync(entity);

				return new BaseResponse<T>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Succeed\n---\nCreated {typeof(T).Name} [id = {entity.Id}]",
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = entity
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<T>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Failed\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.InternalServerError,
					Data = entity
				};
			}
		}

		public async Task<BaseResponse<bool>> AddEntityRangeAsync(IEnumerable<T> entities)
		{
			try
			{
				await _repository.AddRangeAsync(entities);

				return new BaseResponse<bool>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Succeed\n---\nCreated {entities.Count()} {typeof(T).Name}",
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = true
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Failed\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.InternalServerError,
					Data = false
				};
			}
		}

		public BaseResponse<IQueryable<T>> GetAllEntities()
		{
			try
			{
				var entities = _repository.GetAll();

				return new BaseResponse<IQueryable<T>>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Succeed\n---\nFound {entities.Count()} {typeof(T).Name}",
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = entities
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<IQueryable<T>>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Failed\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.InternalServerError,
					Data = null
				};
			}
		}

		public async Task<BaseResponse<T>> GetEntityByIdAsync(int id)
		{
			try
			{
				var entity = await _repository.GetByIdAsync(id);

				return new BaseResponse<T>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Succeed\n---\nFound {typeof(T).Name} [id = {id}]",
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = entity
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<T>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Failed\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.EntityNotFound,
					Data = null
				};
			}
		}

		/*public async Task<BaseResponse<T>> GetUserByName(string name)
		{
			try
			{
				var user = await _repository.GetByName(name);

				return new BaseResponse<T>
				{
					Description = $"Found user [name = {name}]",
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = user
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<T>
				{
					Description = $"GetUserByName Failed\nUser [name = {name}] not found\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.UserNotFound
				};
			}
		}*/

		public async Task<BaseResponse<T>> UpdateEntityAsync(T entity)
		{
			try
			{
				var targetEntity = await _repository.GetByIdAsync(entity.Id);

				targetEntity.UpdateData(entity);

				await _repository.UpdateAsync(targetEntity);

				return new BaseResponse<T>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Succeed\n---\nUpdated {typeof(T).Name} [id = {targetEntity.Id}]",
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = entity
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<T>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Failed\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.InternalServerError,
					Data = entity
				};
			}
		}

		public async Task<BaseResponse<bool>> DeleteEntityByIdAsync(int id)
		{
			try
			{
				var entity = await _repository.GetByIdAsync(id);

				await _repository.DeleteAsync(entity);

				return new BaseResponse<bool>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Succeed\n---\nDeleted {typeof(T).Name} [id = {entity.Id}]",
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = true
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Failed\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.InternalServerError,
					Data = false
				};
			}
		}

		public BaseResponse<T> GetEntityAsync(T entity)
		{
			try
			{
				var targetEntity = _repository.Get(entity);

				return new BaseResponse<T>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Succeed\n---\nFound {typeof(T).Name} [id = {targetEntity.Id}]",
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = targetEntity
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<T>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Failed\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.EntityNotFound,
					Data = entity
				};
			}
		}

		public async Task<BaseResponse<bool>> DeleteEntityAsync(T entity)
		{
			try
			{
				var targetEntity = _repository.Get(entity);

				await _repository.DeleteAsync(targetEntity);

				return new BaseResponse<bool>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Succeed\n---\nDeleted {typeof(T).Name} [id = {targetEntity.Id}]",
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = true
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Failed\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.InternalServerError,
					Data = false
				};
			}
		}

		/*public void Dispose()
		{
			_repository.Dispose();
		}*/

		/*
	   public static implicit operator BaseService<T>(BaseService<User> userService)
	   {
		   return new BaseService<T>();
	   }

	   public static implicit operator BaseService<T>(BaseService<Rating> v)
	   {
		   return new BaseService<T>();
	   }*/

		/*public static explicit operator BaseService<BaseEntity>(BaseService<T> service)
		{
			return new BaseService<BaseEntity>();
		}*/

		/*public static implicit operator BaseService<T>(BaseService<User> v)
		{
			throw new NotImplementedException();
		}*/
	}
}
