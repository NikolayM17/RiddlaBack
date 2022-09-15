using Domain.Entities;
using Domain.Entities.Comment;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class AppDbContext : DbContext
	{
		/*public DbSet<Company> Companies { get; set; }*/

		public string LoremIpsum
		{
			get
			{
				return "Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной \"рыбой\" для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов. Lorem Ipsum не только успешно пережил без заметных изменений пять веков, но и перешагнул в электронный дизайн. Его популяризации в новое время послужили публикация листов Letraset с образцами Lorem Ipsum в 60-х годах и, в более недавнее время, программы электронной вёрстки типа Aldus PageMaker, в шаблонах которых используется Lorem Ipsum.";
			}
		}

		public DbSet<Genre> Genres { get; set; } = null!;
		public DbSet<Tag> Tags { get; set; } = null!;

		public DbSet<ArticleComment> ArticleComments { get; set; } = null!;
		public DbSet<ChapterComment> ChapterComments { get; set; } = null!;
		public DbSet<TitleComment> TitleComments { get; set; } = null!;

		public DbSet<Article> Articles { get; set; } = null!;
		public DbSet<Bookmark> Bookmarks { get; set; } = null!;
		public DbSet<Chapter> Chapters { get; set; } = null!;
		public DbSet<Rating> Ratings { get; set; } = null!;
		public DbSet<Statistics> Statistics { get; set; } = null!;
		public DbSet<Team> Teams { get; set; } = null!;
		public DbSet<Title> Titles { get; set; } = null!;
		public DbSet<User> Users { get; set; } = null!;

		public AppDbContext()
		{
			/*Database.EnsureDeleted();*/
			Database.EnsureCreated();

			/*Users.Add(new User());*/

			/*Set<User>().Add(new User());
			SaveChanges();*/
		}

		/*private async Task FillPrimaryDbData()
		{
        }*/

		public async Task FillPrimaryData()
		{
			await CreatePrimaryData();

			FillGenres();
			FillTags();

			FillUsers();
			FillBookmarks();
			FillTitles();
			FillStatistics();
			FillTeams();
			FillArticles();
			FillChapters();
			FillRatings();

			FillChapterComments();
			FillTitleComments();
			FillArticleComments();

			await SaveChangesAsync();
		}

		private async Task CreatePrimaryData()
		{
			await Genres.AddRangeAsync(CreateGenres());
			await Tags.AddRangeAsync(CreateTags());

			await Users.AddRangeAsync(CreateUsers());
			await Bookmarks.AddRangeAsync(CreateBookmarks());
			await Titles.AddRangeAsync(CreateTitles());
			await Statistics.AddRangeAsync(CreateStatistics());
			await Teams.AddRangeAsync(CreateTeams());
			await Articles.AddRangeAsync(CreateArticles());
			await Chapters.AddRangeAsync(CreateChapters());
			await Ratings.AddRangeAsync(CreateRatings());

			await ChapterComments.AddRangeAsync(CreateChapterComments());
			await TitleComments.AddRangeAsync(CreateTitleComments());
			await ArticleComments.AddRangeAsync(CreateArticleComments());

			await SaveChangesAsync();
		}

		public object? GetDbSet<T>(/*string arrayType, string arrayItemType*/)
		{
			var properties = GetType().GetProperties();

			var result = properties.First(p => p.PropertyType.Name.Contains("DbSet"/*arrayType*/) && p.PropertyType.FullName.Contains(typeof(T).Name /*arrayItemType*/));

			return result.GetValue(this);
		}

		/*public object? GetDbSet(Type type)
		{
			var properties = GetType().GetProperties();

			var result = properties.First(p => p.PropertyType.Name.Contains("DbSet"*//*arrayType*//*) && p.PropertyType.FullName.Contains(type.Name *//*arrayItemType*//*));

			return result.GetValue(this);
		}*/

		/*public async Task FillDbSet<T, K>()
			where T : BaseEntity
			where K : BaseEntity
		{
			var entities = ((DbSet<T>)GetDbSet<T>());

			await entities.ForEachAsync(e => e.GetList<K>().AddRange((DbSet<K>)GetDbSet<K>()));

			/////////

			for (int i = 1; i < 4; i++)
			{
				var entity = await entities.FindAsync(i);

				foreach (var listProperty in entity.GetAllLists())
				{
					*//*listProperty*/

		/* listProperty.GetValue(entity) *//*

		Type genericListType = typeof(List<>).MakeGenericType(listProperty.PropertyType);
		var entityList = (IList)Activator.CreateInstance(genericListType);
		var dbList = (IList)Activator.CreateInstance(genericListType);

		dbList = (IList)GetDbSet(listProperty.PropertyType);

		entityList.Add(dbList[i - 1]);
	}
}

/////////

entities.UpdateRange();
await SaveChangesAsync();
}*/

		/*private async Task FillUsers()
		{
			*/
		/*for (int i = 1; i < 4; i++)
			{
				var properties = GetType().GetProperties();

				if (properties[i].PropertyType.Name == "DbSet`1" && properties[i].PropertyType.FullName.Contains("User"))
				{
					var user = await ((DbSet<User>)properties[i].GetValue(this)).FindAsync(i);

					user.ChapterComments.Add(await ChapterComments.FindAsync(i));
					user.ArticleComments.Add(await ArticleComments.FindAsync(i));
					user.TitleComments.Add(await TitleComments.FindAsync(i));
					user.Bookmarks.Add(await Bookmarks.FindAsync(i));
					user.Articles.Add(await Articles.FindAsync(i));
					user.Ratings.Add(await Ratings.FindAsync(i));
				}
			}*/
		/*

			for (int i = 1; i < 4; i++)
			{
				var user = await Users.FindAsync(i);
				user.ChapterComments.Add(await ChapterComments.FindAsync(i));
				user.ArticleComments.Add(await ArticleComments.FindAsync(i));
				user.TitleComments.Add(await TitleComments.FindAsync(i));
				user.Bookmarks.Add(await Bookmarks.FindAsync(i));
				user.Articles.Add(await Articles.FindAsync(i));
				user.Ratings.Add(await Ratings.FindAsync(i));
			}
			await Users.ForEachAsync(user => user.Teams.AddRange(Teams));

			Users.UpdateRange();
			await SaveChangesAsync();
		}*/

		private IEnumerable<Genre> CreateGenres()
		{
			for (int i = 0; i < 5; i++)
			{
				yield return new Genre
				{
					Name = $"DbGenre_{i}"
				};
			}
		}
		private void FillGenres()
		{
			foreach (var genre in Genres)
			{
				genre.FillLists(this);
				Genres.Update(genre);
			}

			Genres.UpdateRange();

			SaveChanges();
		}

		private IEnumerable<Tag> CreateTags()
		{
			for (int i = 0; i < 5; i++)
			{
				yield return new Tag
				{
					Name = $"DbTag_{i}"
				};
			}
		}
		private void FillTags()
		{
			foreach (var tag in Tags)
			{
				tag.FillLists(this);
				Tags.Update(tag);
			}

			Tags.UpdateRange();

			SaveChanges();
		}

		private IEnumerable<User> CreateUsers()
		{
			for (int i = 0; i < 3; i++)
			{
				yield return new User
				{
					Name = $"DbUser_{i}",
					Password = "12345",
					UserType = UserType.Reader/*,
					Image*/
				};
			}
		}
		private void FillUsers()
		{
			foreach (var user in Users)
			{
				user.FillLists(this);
				Users.Update(user);
			}

			Users.UpdateRange();

			SaveChanges();
		}

		private IEnumerable<Statistics> CreateStatistics()
		{
			for (int i = 1; i < 4; i++)
			{
				yield return new Statistics
				{
					Views = 10492 * i,
					Likes = 3758 * i,
					Comments = 1225 * i
				};
			}
		}
		private void FillStatistics()
		{
			foreach (var item in Statistics) item.FillLists(this);
			Statistics.UpdateRange();
		}

		private IEnumerable<Rating> CreateRatings()
		{
			for (int i = 2; i < 5; i++)
			{
				yield return new Rating
				{
					Value = i
				};
			};
		}
		private void FillRatings()
		{
			foreach (var item in Ratings) item.FillLists(this);
			Ratings.UpdateRange();
		}

		private IEnumerable<Team> CreateTeams()
		{
			for (int i = 0; i < 3; i++)
			{
				yield return new Team
				{
					Name = $"DbTeam_{i}"/*,
					Image*/
				};
			}
		}
		private void FillTeams()
		{
			foreach (var item in Teams) item.FillLists(this);
			Teams.UpdateRange();
		}

		private IEnumerable<Article> CreateArticles()
		{
			for (int i = 1; i < 4; i++)
			{
				var notExactlyNow = DateTime.Now.AddDays(-i);

				yield return new Article
				{
					Name = $"DbArticle_{i}",
					Text = LoremIpsum,
					Date = notExactlyNow
				};
			};
		}
		private void FillArticles()
		{
			foreach (var item in Articles) item.FillLists(this);
			Articles.UpdateRange();
		}

		private IEnumerable<Title> CreateTitles()
		{
			for (int i = 0; i < 3; i++)
			{
				yield return new Title
				{
					Name = $"БДТайтл_{i}",
					EnName = $"DbTitle_{i}",
					Description = LoremIpsum,
					Year = 2020 + i,
					TitleType = (TitleType)i,
					StatusOriginal = (StatusOriginal)i,
					StatusTranslation = (StatusTranslation)i
				};
			}
		}
		private void FillTitles()
		{
			foreach (var item in Titles) item.FillLists(this);
			Titles.UpdateRange();
		}

		private IEnumerable<Chapter> CreateChapters()
		{
			for (int i = 1; i < 4; i++)
			{
				var notExactlyNow = DateTime.Now.AddDays(-i);

				yield return new Chapter
				{
					Name = $"DbChapter_{i}",
					Text = LoremIpsum,
					Date = notExactlyNow
				};
			};
		}
		private void FillChapters()
		{
			foreach (var item in Chapters) item.FillLists(this);
			Chapters.UpdateRange();
		}

		private IEnumerable<Bookmark> CreateBookmarks()
		{
			for (int i = 0; i < 3; i++)
			{
				yield return new Bookmark
				{
					TabType = (TabType)i
				};
			};
		}
		private void FillBookmarks()
		{
			foreach (var item in Bookmarks) item.FillLists(this);
			Bookmarks.UpdateRange();
		}

		private IEnumerable<ArticleComment> CreateArticleComments()
		{
			for (int i = 0; i < 3; i++)
			{
				var notExactlyNow = DateTime.Now.AddDays(-i);

				yield return new ArticleComment
				{
					Text = LoremIpsum,
					Date = notExactlyNow
				};
			};
		}
		private void FillArticleComments()
		{
			foreach (var item in ArticleComments) item.FillLists(this);
			ArticleComments.UpdateRange();
		}

		private IEnumerable<TitleComment> CreateTitleComments()
		{
			for (int i = 0; i < 3; i++)
			{
				var notExactlyNow = DateTime.Now.AddDays(-i);

				yield return new TitleComment
				{
					Text = LoremIpsum,
					Date = notExactlyNow
				};
			};
		}
		private void FillTitleComments()
		{
			foreach (var item in TitleComments) item.FillLists(this);
			TitleComments.UpdateRange();
		}

		private IEnumerable<ChapterComment> CreateChapterComments()
		{
			for (int i = 0; i < 3; i++)
			{
				var notExactlyNow = DateTime.Now.AddDays(-i);

				yield return new ChapterComment
				{
					Text = LoremIpsum,
					Date = notExactlyNow
				};
			};
		}
		private void FillChapterComments()
		{
			foreach (var item in ChapterComments) item.FillLists(this);
			ChapterComments.UpdateRange();
		}


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=riddladb4;Trusted_Connection=True;MultipleActiveResultSets=true;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			/*modelBuilder.Entity<User>()
				.HasOne(p => p.Company)
				.WithMany(t => t.Users)
				.OnDelete(DeleteBehavior.SetNull);*/

			/*modelBuilder.Entity<>().Navigation(e => e.ColorScheme).AutoInclude();*/

			modelBuilder.Entity<User>().Navigation(u => u.Ratings).AutoInclude();

			modelBuilder.Entity<Title>().Navigation(t => t.Ratings).AutoInclude();
			modelBuilder.Entity<Title>().Navigation(t => t.Bookmarks).AutoInclude();
			modelBuilder.Entity<Title>().Navigation(t => t.Chapters).AutoInclude();
			modelBuilder.Entity<Title>().Navigation(t => t.Genres).AutoInclude();
			modelBuilder.Entity<Title>().Navigation(t => t.Tag).AutoInclude();


			modelBuilder.Entity<Genre>()
				.HasMany(genre => genre.Titles)
				.WithMany(title => title.Genres)
				.UsingEntity(builder => builder.ToTable("GenreTitleConnection"));

			modelBuilder.Entity<Tag>()
				.HasMany(tag => tag.Titles)
				.WithMany(title => title.Tag)
				.UsingEntity(builder => builder.ToTable("TagTitleConnection"));



			modelBuilder.Entity<User>()
				.HasMany(user => user.Teams)
				.WithMany(team => team.Users)
				.UsingEntity(builder => builder.ToTable("UserTeamConnection"));

			modelBuilder.Entity<User>()
				.HasOne(user => user.Statistics)
				.WithMany(statistics => statistics.Users)
				.OnDelete(DeleteBehavior.SetNull);


			modelBuilder.Entity<Rating>()
				.HasOne(rating => rating.Title)
				.WithMany(title => title.Ratings)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Rating>()
				.HasOne(rating => rating.User)
				.WithMany(user => user.Ratings)
				.OnDelete(DeleteBehavior.SetNull);


			modelBuilder.Entity<Team>()
				.HasOne(team => team.Statistics)
				.WithMany(statistics => statistics.Teams)
				.OnDelete(DeleteBehavior.SetNull);


			modelBuilder.Entity<Bookmark>()
				.HasOne(bookmark => bookmark.Title)
				.WithMany(title => title.Bookmarks)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Bookmark>()
				.HasOne(bookmark => bookmark.User)
				.WithMany(user => user.Bookmarks)
				.OnDelete(DeleteBehavior.SetNull);



			modelBuilder.Entity<Title>()
				.HasMany(title => title.Teams)
				.WithMany(team => team.Titles)
				.UsingEntity(builder => builder.ToTable("TitleTeamConnection"));

			modelBuilder.Entity<TitleComment>()
				.HasOne(titleComment => titleComment.Title)
				.WithMany(title => title.TitleComments)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<TitleComment>()
				.HasOne(titleComment => titleComment.User)
				.WithMany(user => user.TitleComments)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<TitleComment>()
				.HasOne(titleComment => titleComment.Statistics)
				.WithMany(statistics => statistics.TitleComments)
				.OnDelete(DeleteBehavior.SetNull);


			modelBuilder.Entity<Chapter>()
				.HasOne(chapter => chapter.Title)
				.WithMany(title => title.Chapters)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Chapter>()
				.HasOne(chapter => chapter.Statistics)
				.WithMany(statistics => statistics.Chapters)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<ChapterComment>()
				.HasOne(chapterComment => chapterComment.User)
				.WithMany(user => user.ChapterComments)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<ChapterComment>()
				.HasOne(chapterComment => chapterComment.Chapter)
				.WithMany(chapter => chapter.ChapterComments)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<ChapterComment>()
				.HasOne(chapterComment => chapterComment.Statistics)
				.WithMany(statistics => statistics.ChapterComments)
				.OnDelete(DeleteBehavior.SetNull);


			modelBuilder.Entity<Article>()
				.HasOne(article => article.User)
				.WithMany(user => user.Articles)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Article>()
				.HasOne(article => article.Statistics)
				.WithMany(statistics => statistics.Articles)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<ArticleComment>()
				.HasOne(chapterComment => chapterComment.User)
				.WithMany(user => user.ArticleComments)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<ArticleComment>()
				.HasOne(chapterComment => chapterComment.Article)
				.WithMany(article => article.ArticleComments)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<ArticleComment>()
				.HasOne(chapterComment => chapterComment.Statistics)
				.WithMany(statistics => statistics.ArticleComments)
				.OnDelete(DeleteBehavior.SetNull);


			/*modelBuilder.Entity<User>(builder =>
			{
				builder.HasKey(user => user.Id);

				builder.HasData(new User
				{
					Name = "OnCreatingUser"
				});
			});*/
		}
	}
}
