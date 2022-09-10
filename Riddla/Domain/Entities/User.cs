using DAL;
using Domain.Entities.Comment;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
	public class User : BaseEntity
	{
		/*public User(string name, string password, UserType userType = UserType.Reader)
		{
			Name = name;
			Password = password;
			UserType = userType;
		}*/

		/*public int Id { get; set; }*/

		/*[Required(ErrorMessage = "Укажите имя")]
		[MaxLength(20, ErrorMessage = "Имя должно иметь длину меньше 20 символов")]
		[MinLength(3, ErrorMessage = "Имя должно иметь длину больше 3 символов")]*/
		public string? Name { get; set; }

		/*[DataType(DataType.Password)]
		[Required(ErrorMessage = "Укажите пароль")]
		[MinLength(6, ErrorMessage = "Пароль должен иметь длину больше 6 символов")]*/
		public string? Password { get; set; }

		/*[Required(ErrorMessage = "Укажите почту")]
		[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]*/
		public string? Email { get; set; }
		public /*byte[]*/ string? Image { get; set; }
		public UserType? UserType { get; set; }

		public int? StatisticsId { get; set; }
		public Statistics? Statistics { get; set; }

		public List<ChapterComment> ChapterComments { get; set; } = new();
		public List<TitleComment> TitleComments { get; set; } = new();
		public List<Article> Articles { get; set; } = new();
		public List<ArticleComment> ArticleComments { get; set; } = new();
		public List<Bookmark> Bookmarks { get; set; } = new();
		public List<Rating> Ratings { get; set; } = new();

		public List<Team> Teams { get; set; } = new();


		public override void FillLists(AppDbContext db)
		{
			ChapterComments.AddRange(db.ChapterComments);
			TitleComments.AddRange(db.TitleComments);
			Articles.AddRange(db.Articles);
			ArticleComments.AddRange(db.ArticleComments);
			Bookmarks.AddRange(db.Bookmarks);
			Ratings.AddRange(db.Ratings);
		}

		public override void UpdateData(object entity)
		{
			if (entity is User user)
			{
				Name = user.Name;
				Password = user.Password;
				Image = user.Image;
				UserType = user.UserType;
				StatisticsId = user.StatisticsId;
				Statistics = user.Statistics;
				Teams = user.Teams;
				ChapterComments = user.ChapterComments;
				TitleComments = user.TitleComments;
				Articles = user.Articles;
				ArticleComments = user.ArticleComments;
				Bookmarks = user.Bookmarks;
				Ratings = user.Ratings;
			}
			else throw new Exception($"Error convert!\n{this.GetType()}");
		}

		/*public abstract void UpdateData(BaseEntity entity);*/
	}
}
