﻿using Domain.Entities.Comment;
using Domain.Enums;
using rofel.Domain.Entities;

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
		public string? Name { get; set; }
		public string? Password { get; set; }
		public /*byte[]*/ string? Image { get; set; }
		public UserType? UserType { get; set; }

		public int? StatisticsId { get; set; }
		public Statistics Statistics { get; set; }

		public List<Team>? Teams { get; set; } = new();

		public List<ChapterComment>? ChapterComments  { get; set; } = new();

		public List<TitleComment>? TitleComments { get; set; } = new();

		public List<Article>? Articles { get; set; } = new();
		public List<ArticleComment>? ArticleComments { get; set; } = new();

		public List<Bookmark>? Bookmarks { get; set; } = new();

		public List<Rating>? Ratings { get; set; }/* = new();*/

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