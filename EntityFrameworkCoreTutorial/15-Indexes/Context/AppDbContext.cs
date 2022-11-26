using _15_Indexes.Entities;
using Microsoft.EntityFrameworkCore;

namespace _15_Indexes.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:/Users/USER/Desktop/Yeni klasör/Tutorials/EntityFrameworkCoreTutorial/15-Indexes/AppDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Indexleme
            modelBuilder.Entity<Employee>()
            .HasIndex(e => e.Name);

            // Composite Indexleme
            modelBuilder.Entity<Employee>()
            .HasIndex(e => new { e.Name, e.LastName });

        }
    }
}