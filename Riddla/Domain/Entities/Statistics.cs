using DAL;
using Domain.Entities.Comment;

namespace Domain.Entities
{
	public class Statistics : BaseEntity
	{
		/*public int Id { get; set; }*/
		public int? Views { get; set; }
		public int? Likes { get; set; }
		public int? Comments { get; set; }

		public List<Chapter> Chapters { get; set; } = new();
		public List<ChapterComment> ChapterComments { get; set; } = new();

		public List<Article> Articles { get; set; } = new();
		public List<ArticleComment> ArticleComments  { get; set; } = new();

		public List<Title> Titles  { get; set; } = new();
		public List<TitleComment> TitleComments  { get; set; } = new();

		public List<User> Users { get; set; } = new();
		public List<Team> Teams { get; set; } = new();

		public override void FillLists(AppDbContext db)
		{
			Chapters.AddRange(db.Chapters);
			ChapterComments.AddRange(db.ChapterComments);
			Articles.AddRange(db.Articles);
			ArticleComments.AddRange(db.ArticleComments);
			Titles.AddRange(db.Titles);
			TitleComments.AddRange(db.TitleComments);
			Users.AddRange(db.Users);
			Teams.AddRange(db.Teams);
		}

		public override void UpdateData(object entity)
		{
			if (entity is Statistics statistics)
			{
				Views = statistics.Views;
				Likes = statistics.Likes;
				Comments = statistics.Comments;
			}
			else throw new Exception($"Error convert!\n{this.GetType()}");
		}
	}
}
