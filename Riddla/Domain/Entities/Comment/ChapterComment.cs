namespace Domain.Entities.Comment
{
	public class ChapterComment : Comment
	{
		public int? UserId { get; set; }
		public User User { get; set; }

		public int? ChapterId { get; set; }
		public Chapter Chapter { get; set; }

		public int? StatisticsId { get; set; }
		public Statistics Statistics { get; set; }
	}
}
