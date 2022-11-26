
using _13_TablePerConcrete_TPC_.Entities;
using Microsoft.EntityFrameworkCore;

namespace _13_TablePerConcrete_TPC_.Context
{
    public class AppDbContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:/Users/USER/Desktop/Yeni klasör/Tutorials/EntityFrameworkCoreTutorial/13-TablePerConcrete(TPC)/AppDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TPC uygulamak icin
            modelBuilder.Entity<Person>().UseTpcMappingStrategy();


        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Technician> Technicians { get; set; }

    }
}