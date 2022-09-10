using Domain.Entities;
using Riddla.DAL.Repositories;
using Service.Helpers;
using Service.Implementations;

namespace Riddla.Service.Implementations
{
	public class TitleService : BaseService<Title>, IBaseService<Title>
	{
		public TitleService()
		{
			_repository = new TitleRepository();
		}

		public new BaseResponse<Title> GetEntity(Title entity)
		{
			try
			{
				var targetEntity = _repository.Get(entity);

				return new BaseResponse<Title>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Succeed\n---\nFound {typeof(Title).Name} [id = {targetEntity.Id}]",
					StatusCode = Riddla.Domain.Enums.StatusCode.OK,
					Data = targetEntity
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<Title>
				{
					Description = $"{MethodHelper.GetCurrentMethodName()} Failed\n---\n{ex.Message}",
					StatusCode = Riddla.Domain.Enums.StatusCode.EntityNotFound,
					Data = entity
				};
			}
		}
	}
}
