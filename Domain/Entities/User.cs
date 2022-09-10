using DAL;
using Domain.Entities.Comment;
using Domain.Enums;

namespace Domain.Entities
{
	public class User : BaseEntity
	{
		public string? Name { get; set; }
		public string? Password { get; set; }
		public string? Email { get; set; }
		public string? Image { get; set; }
		public UserType? UserType { get; set; }
		public int? StatisticsId { get; set; }
		public Statistics Statistics { get; set; }

		public List<ChapterComment> ChapterComments  { get; set; } = new();
		public List<TitleComment> TitleComments { get; set; } = new();
		public List<Article> Articles { get; set; } = new();
		public List<ArticleComment> ArticleComments { get; set; } = new();
		public List<Bookmark> Bookmarks { get; set; } = new();
		public List<Rating> Ratings { get; set; } = new();

		public List<Team> Teams { get; set; } = new();


		public override void FillLists(AppDbContext db)
		{
			ChapterComments.AddRange(db.ChapterComments);
			TitleComments.AddRange(db.TitleComments);
			Articles.AddRange(db.Articles);
			ArticleComments.AddRange(db.ArticleComments);
			Bookmarks.AddRange(db.Bookmarks);
			Ratings.AddRange(db.Ratings);

			Teams.AddRange(db.Teams);
		}

		public override void UpdateData(object entity)
		{
			if (entity is User user)
			{
				Name = user.Name;
				Password = user.Password;
				Image = user.Image;
				UserType = user.UserType;
				StatisticsId = user.StatisticsId;
				Statistics = user.Statistics;
				Teams = user.Teams;
				ChapterComments = user.ChapterComments;
				TitleComments = user.TitleComments;
				Articles = user.Articles;
				ArticleComments = user.ArticleComments;
				Bookmarks = user.Bookmarks;
				Ratings = user.Ratings;
			}
			else throw new Exception($"Error convert!\n{this.GetType()}");
		}
	}
}
