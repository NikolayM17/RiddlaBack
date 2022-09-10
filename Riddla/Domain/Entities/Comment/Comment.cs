namespace Domain.Entities.Comment
{
	public class Comment : BaseEntity
	{
		public string? Text { get; set; }
		public DateTime? Date { get; set; }
	}
}
