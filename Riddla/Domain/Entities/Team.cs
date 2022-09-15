using DAL;

namespace Domain.Entities
{
	public class Team : BaseEntity
	{
		/*public int Id { get; set; }*/
		public string? Name { get; set; }
		public string? Image { get; set; }

		public int? StatisticsId { get; set; }
		public Statistics Statistics { get; set; }

		public List<User> Users { get; set; } = new();
		public List<Title> Titles { get; set; } = new();

		public override void FillLists(AppDbContext db)
		{
			Users.AddRange(db.Users);
			Titles.AddRange(db.Titles);
		}

		public override void UpdateData(object entity)
		{
			if (entity is Team team)
			{
				Name = team.Name;
				Image = team.Image;
			}
			else throw new Exception($"Error convert!\n{this.GetType()}");
		}
	}
}
