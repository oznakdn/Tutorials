using System.Reflection;
using _10_SeedData.Entities;
using Microsoft.EntityFrameworkCore;

namespace _10_SeedData.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
            .HasMany(b => b.Posts)
            .WithOne(b => b.Blog)
            .HasForeignKey(b => b.BlogId);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:/Users/USER/Desktop/Yeni klasör/Tutorials/EntityFrameworkCoreTutorial/10-SeedData/AppDB.db");
        }

    }
}