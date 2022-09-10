using Domain.Entities;
using Riddla.DAL.Repositories;
using Service.Helpers;
using Service.Implementations;

namespace Riddla.Service.Implementations
{
	public class UserService : BaseService<User>, IBaseService<User>
	{
		public UserService()
		{
			_repository = new UserRepository();
		}

		public new BaseResponse<User> GetEntity(User entity)
		{
			try
			{
				var targetEntity = _repository.Get(entity);

				return new BaseResponse<User>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Succeed\n---\nFound {typeof(User).Name} [id = {targetEntity.Id}]",
					StatusCode = Riddla.Domain.Enums.StatusCode.OK,
					Data = targetEntity
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<User>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Failed\n---\n{ex.Message}",
					StatusCode = Riddla.Domain.Enums.StatusCode.EntityNotFound,
					Data = entity
				};
			}
		}
	}
}
