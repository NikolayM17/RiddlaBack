using Domain.Entities.Comment;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
	public class Chapter : BaseEntity
	{
		/*public int Id { get; set; }*/
		public string? Name { get; set; }
		public string? Text { get; set; }
		public DateTime? Date { get; set; }
		
		public int? TitleId { get; set; }
		public Title Title { get; set; }
		public int? StatisticsId { get; set; }
		public Statistics Statistics { get; set; }

		public List<ChapterComment>? ChapterComments { get; set; } = new();

		public override void UpdateData(object entity)
		{
			if (entity is Chapter chapter)
			{
				Name = chapter.Name;
				Text = chapter.Text;
				Date = chapter.Date;
			}
			else throw new Exception($"Error convert!\n{this.GetType()}");
		}
	}
}
