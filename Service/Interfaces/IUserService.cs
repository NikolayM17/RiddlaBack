using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces
{
	public interface IUserService
	{
		BaseResponse<IQueryable<User>> GetUsers();
		Task<BaseResponse<User>> GetUserById(int id);
		/*Task<BaseResponse<User>> GetUserByName(string name);*/
		Task<BaseResponse<User>> CreateUser(User user);
		Task<BaseResponse<User>> EditUser(User user);
		Task<BaseResponse<bool>> DeleteUser(int id);
	}
}
