namespace Domain.Entities.Comment
{
	public class ArticleComment : Comment
	{
		public int? UserId { get; set; }
		public User User { get; set; }

		public int? ArticleId { get; set; }
		public Article Article { get; set; }

		public int? StatisticsId { get; set; }
		public Statistics Statistics { get; set; }
	}
}
