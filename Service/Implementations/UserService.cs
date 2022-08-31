using Domain.Entities;
using rofel.DAL;
using rofel.DAL.Repositories;
using rofel.Domain.Entities;
using rofel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace rofel.Service.Implementations
{
	public class UserService<T> : IUserService
	{
		private readonly IBaseRepository<User> _repository;


		public UserService()
		{
			_repository = new UserRepository();
		}

		public UserService(IBaseRepository<User> repository)
		{
			_repository = repository;
		}

		public async Task<BaseResponse<User>> CreateUser(User user)
		{
			try
			{
				await _repository.AddAsync(user);

				return new BaseResponse<User>
				{
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = user
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<User>
				{
					Description = $"CreateUser Failed\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.InternalServerError,
					Data = user
				};
			}
		}

		public BaseResponse<IQueryable<User>> GetUsers()
		{
			try
			{
				var users = _repository.GetAll();

				return new BaseResponse<IQueryable<User>>
				{
					Description = $"Found {users.Count()}",
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = users
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<IQueryable<User>>
				{
					Description = $"GetUsers Failed\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.InternalServerError
				};
			}
		}

		public async Task<BaseResponse<User>> GetUserById(int id)
		{
			try
			{
				var user = await _repository.GetByIdAsync(id);

				return new BaseResponse<User>
				{
					Description = $"Found user [id = {id}]",
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = user
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<User>
				{
					Description = $"GetUserById Failed\nUser [id = {id}] not found\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.UserNotFound
				};
			}
		}

		/*public async Task<BaseResponse<User>> GetUserByName(string name)
		{
			try
			{
				var user = await _repository.GetByName(name);

				return new BaseResponse<User>
				{
					Description = $"Found user [name = {name}]",
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = user
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<User>
				{
					Description = $"GetUserByName Failed\nUser [name = {name}] not found\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.UserNotFound
				};
			}
		}*/

		public async Task<BaseResponse<User>> EditUser(User user)
		{
			try
			{
				var targetUser = await _repository.GetByIdAsync(user.Id);

				targetUser.UpdateData(user);

				await _repository.UpdateAsync(targetUser);

				return new BaseResponse<User>
				{
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = user
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<User>
				{
					Description = $"EditUser Failed\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.InternalServerError
				};
			}
		}

		public async Task<BaseResponse<bool>> DeleteUser(int id)
		{
			try
			{
				var user = await _repository.GetByIdAsync(id);

				await _repository.DeleteAsync(user);

				return new BaseResponse<bool>
				{
					StatusCode = Domain.Enums.StatusCode.OK,
					Data = true
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>
				{
					Description = $"DeleteUser Failed\n---\n{ex.Message}",
					StatusCode = Domain.Enums.StatusCode.InternalServerError,
					Data = false
				};
			}
		}
	}
}
