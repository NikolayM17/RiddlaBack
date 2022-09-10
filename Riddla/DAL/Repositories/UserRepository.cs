using DAL.Interfaces;
using DAL.Repositories;
using Domain.Entities;

namespace Riddla.DAL.Repositories
{
	public class UserRepository : BaseRepository<User>, IBaseRepository<User>
	{
		public new User? Get(User entity)
		{
			return _db.Users.FirstOrDefault(u =>
				u.Name == entity.Name &&
				u.Password == entity.Password);
		}
	}
}
