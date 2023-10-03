using Microsoft.EntityFrameworkCore;
using Questions.Entities.Entities;

namespace Questions.DAL
{
    public class QuestionsDbContext : DbContext
    {
        // DbSet for User entity
        public DbSet<User> Users { get; set; }

        // DbSet for Question entity
        public DbSet<Question> Questions { get; set; }

        // DbSet for Answer entity
        public DbSet<Answer> Answers { get; set; }

        // DbSet for QuestionTag entity
        public DbSet<QuestionTag> QuestionTags { get; set; }

        // DbSet for Vote entity
        public DbSet<Vote> Votes { get; set; }

        public QuestionsDbContext(DbContextOptions<QuestionsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de las relaciones entre entidades

            modelBuilder.Entity<Question>()
                .HasOne(q => q.User)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.UserId);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.User)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.UserId);

            modelBuilder.Entity<Question>()
                .HasMany(m => m.QuestionTags)
                .WithOne(dm => dm.Question)
                .HasForeignKey(dm => dm.QuestionId);

            modelBuilder.Entity<Question>()
                .HasMany(m => m.Answers)
                .WithOne(dm => dm.Question)
                .HasForeignKey(dm => dm.QuestionId);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.User)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<QuestionTag>()
                .HasKey(qt => new { qt.QuestionId, qt.TagName });

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.User)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.UserId);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Question)
                .WithMany(q => q.Votes)
                .HasForeignKey(v => v.QuestionId);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Answer)
                .WithMany(a => a.Votes)
                .HasForeignKey(v => v.AnswerId);
        }
    }
}
