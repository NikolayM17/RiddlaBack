using Domain.Entities.Comment;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
	public class Statistics : BaseEntity
	{
		/*public int Id { get; set; }*/
		public int? Views { get; set; }
		public int? Likes { get; set; }
		public int? Comments { get; set; }

		public List<Chapter>? Chapters { get; set; } = new();
		public List<ChapterComment>? ChapterComments { get; set; } = new();

		public List<Article>? Articles { get; set; } = new();
		public List<ArticleComment>? ArticleComments  { get; set; } = new();

		public List<Title>? Titles  { get; set; } = new();
		public List<TitleComment>? TitleComments  { get; set; } = new();

		public List<User>? Users { get; set; } = new();
		public List<Team>? Teams { get; set; } = new();

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
