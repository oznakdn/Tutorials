using System.Reflection;
using _09_EntityConfiguration.Entities;
using Microsoft.EntityFrameworkCore;

namespace _09_EntityConfiguration.Context
{
    public class AppDbContext : DbContext
    {

        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:/Users/USER/Desktop/Yeni klasör/Tutorials/EntityFrameworkCoreTutorial/09-EntityConfiguration/AppDB.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }


}