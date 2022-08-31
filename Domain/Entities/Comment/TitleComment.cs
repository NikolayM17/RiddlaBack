namespace Domain.Entities.Comment
{
	public class TitleComment : Comment
	{
		public int? UserId { get; set; }
		public User User { get; set; }

		public int? TitleId { get; set; }
		public Title Title { get; set; }

		public int? StatisticsId { get; set; }
		public Statistics Statistics { get; set; }
	}
}
