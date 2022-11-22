using _11_TablePerHierarchy_TPH_.Entities;
using Microsoft.EntityFrameworkCore;

namespace _11_TablePerHierarchy_TPH_.Context
{
    public class AppDbContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:/Users/USER/Desktop/Yeni klasör/Tutorials/EntityFrameworkCoreTutorial/11-TablePerHierarchy(TPH)/AppDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Discriminator colonunun adini veye tipini degirtirmek icin

            modelBuilder.Entity<Person>()
            .HasDiscriminator<string>("Ayirici");

            model.builder.Entity<Person>()
            .HasDiscriminator<string>("Ayirici")
            .HasValue<Person>(1)
            .HasValue<Customer>(2)
            .HasValue<Employee>(3)
            .HasValue<Technician>(4)

            */

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Technician> Technicians { get; set; }

    }
}