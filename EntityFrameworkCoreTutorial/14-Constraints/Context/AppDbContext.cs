using _14_Constraints.Entities;
using Microsoft.EntityFrameworkCore;

namespace _14_Constraints.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:/Users/USER/Desktop/Yeni klasör/Tutorials/EntityFrameworkCoreTutorial/14-Constraints/AppDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Key
            modelBuilder.Entity<Post>()
            .HasKey(p => p.Id);

            modelBuilder.Entity<Blog>()
            .HasKey(b => b.Id)
            .HasName("BlogID");

            // Alternate Key (unique constraint)
            modelBuilder.Entity<Post>()
            .HasAlternateKey(p => p.Title);

            // Composite Alternate Key (unique constraint)
            modelBuilder.Entity<Blog>()
            .HasAlternateKey(b => new { b.BlogName, b.Url });

            // Foreign Key
            modelBuilder.Entity<Blog>()
            .HasMany(b => b.Posts)
            .WithOne(p => p.Blog)
            .HasForeignKey(p => p.BlogId);

            // Unique
            modelBuilder.Entity<Post>()
            .HasIndex(p => p.BlogUrl)
            .IsUnique();

            // Check
            // modelBuilder.Entity<Post>()
            // .HasCheckConstraint("BlogUrl_Check", "[BlogUrl] CONTAINS 'http://'");

        }

    }
}