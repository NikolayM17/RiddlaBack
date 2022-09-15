using DAL;

namespace Domain.Entities
{
	public class Tag : BaseEntity
	{
		public string? Name { get; set; }

		public List<Title> Titles { get; set; } = new();


		public override void FillLists(AppDbContext db)
		{
			Titles.AddRange(db.Titles);
		}
	}
}
