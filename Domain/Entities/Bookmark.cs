using Domain.Enums;
using rofel.Domain.Entities;

namespace Domain.Entities
{
	public class Bookmark : BaseEntity
	{
		/*public int Id { get; set; }*/
		public TabType? TabType { get; set; }

		public int? UserId { get; set; }
		public User User { get; set; }

		public int? TitleId { get; set; }
		public Title Title { get; set; }

		public override void UpdateData(object entity)
		{
			if (entity is Bookmark bookmark)
			{
				TabType = bookmark.TabType;
			}
			else throw new Exception($"Error convert!\n{this.GetType()}");
		}
	}
}
