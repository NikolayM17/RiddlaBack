using DAL.Interfaces;
using DAL.Repositories;
using Domain.Entities;

namespace Riddla.DAL.Repositories
{
	public class TitleRepository : BaseRepository<Title>, IBaseRepository<Title>
	{
		public new Title? Get(Title title)
		{
			return _db.Titles.FirstOrDefault(t =>
				t.Name.Contains(title.Name) ||
				t.EnName.Contains(title.EnName));
		}
	}
}
