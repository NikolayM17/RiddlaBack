using Domain.Entities;
using Domain.Entities.Comment;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class AppDbContext : DbContext
    {
        /*public DbSet<Company> Companies { get; set; }*/

        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<ChapterComment> ChapterComments { get; set; }
        public DbSet<TitleComment> TitleComments { get; set; }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext()
        {
			/*Database.EnsureDeleted();*/
			Database.EnsureCreated();

			/*Users.Add(new User());*/

			/*Set<User>().Add(new User());
			SaveChanges();*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=riddladb;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			/*modelBuilder.Entity<User>()
				.HasOne(p => p.Company)
				.WithMany(t => t.Users)
				.OnDelete(DeleteBehavior.SetNull);*/

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
        }
	}
}
