using System;

namespace Domain.Entities.Comment
{
	public class Comment
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public DateTime Date { get; set; }
	}
}
