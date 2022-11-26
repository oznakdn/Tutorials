
using _12_TablePerType_TPT_.Entities;
using Microsoft.EntityFrameworkCore;

namespace _12_TablePerType_TPT_.Context
{
    public class AppDbContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:/Users/USER/Desktop/Yeni klasör/Tutorials/EntityFrameworkCoreTutorial/12-TablePerType(TPT)/AppDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TPT uygulamak icin
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Technician>().ToTable("Tecnicians");


        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Technician> Technicians { get; set; }

    }
}