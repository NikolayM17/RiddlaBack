using Domain.Entities.Comment;
using rofel.Domain.Entities;

namespace Domain.Entities
{
	public class Article : BaseEntity
	{
		/*public int Id { get; set; }*/
		public string? Name { get; set; }
		public string? Text { get; set; }
		public DateTime? Date { get; set; }

		public int? UserId { get; set; }
		public User User { get; set; }

		public int? StatisticsId { get; set; }
		public Statistics Statistics { get; set; }

		public List<ArticleComment>? ArticleComments { get; set; } = new();

		public override void UpdateData(object entity)
		{
			if (entity is Article article)
			{
				Name = article.Name;
				Text = article.Text;
				Date = article.Date;
			}
			else throw new Exception($"Error convert!\n{this.GetType()}");
		}
	}
}
