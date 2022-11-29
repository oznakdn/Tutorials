using _16_Sequences.Entities;
using Microsoft.EntityFrameworkCore;

namespace _16_Sequences.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:/Users/USER/Desktop/Yeni klasör/Tutorials/EntityFrameworkCoreTutorial/16-Sequences/AppDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence("EC_Secuence");

            modelBuilder.Entity<Employee>()
            .Property(e => e.Id).HasDefaultValueSql("NEXT VALUE FOR EC_Secuence");

            modelBuilder.Entity<Customer>()
            .Property(c => c.Id).HasDefaultValueSql("NEXT VALUE FOR EC_Secuence");
        }

    }
}