using Domain.Entities.Comment;
using Domain.Enums;
using rofel.Domain.Entities;

namespace Domain.Entities
{
	public class Title : BaseEntity
	{
		/*public int Id { get; set; }*/
		public string? Name { get; set; }
		public string? EnName { get; set; }
		public string? Description { get; set; }
		public int? AverageRating { get; set; }
		public int? NumberOfRatings { get; set; }
		public int? NumberOfBookmarks { get; set; }
		public int? Year { get; set; }
		public /*byte[]*/ string? Image { get; set; }
		public TitleType? TitleType { get; set; }
		public StatusOriginal? StatusOriginal { get; set; }
		public StatusTranslation? StatusTranslation { get; set; }

		public List<Chapter>? Chapters { get; set; } = new();
		public List<Team>? Teams { get; set; } = new();
		public List<Rating>? Ratings { get; set; } = new();
		public List<Bookmark>? Bookmarks { get; set; } = new();
		public List<TitleComment>? TitleComments { get; set; } = new();

		public override void UpdateData(object entity)
		{
			if (entity is Title title)
			{
				Name = title.Name;
				EnName = title.EnName;
				Description = title.Description;
				AverageRating = title.AverageRating;
				NumberOfRatings = title.NumberOfRatings;
				NumberOfBookmarks = title.NumberOfBookmarks;
				Year = title.Year;
				Image = title.Image;
				TitleType = title.TitleType;
				StatusOriginal = title.StatusOriginal;
				StatusTranslation = title.StatusTranslation;
			}
			else throw new Exception($"Error convert!\n{this.GetType()}");
		}
	}
}
