using _18_ExplicitLoading.Entities;
using Microsoft.EntityFrameworkCore;

namespace _18_ExplicitLoading.Context
{
    public class AppDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:/Users/USER/Desktop/Yeni klasör/Tutorials/EntityFrameworkCoreTutorial/18-ExplicitLoading/AppDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .HasMany(e => e.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);


            modelBuilder.Entity<Region>()
            .HasMany(r => r.Customers)
            .WithOne(e => e.Region)
            .HasForeignKey(e => e.RegionId);

            modelBuilder.Entity<Region>()
            .HasData(
                new Region
                {
                    Id = 1,
                    RegionName = "Ankara"
                },
                new Region
                {
                    Id = 2,
                    RegionName = "Bursa"
                }
            );

            modelBuilder.Entity<Customer>()
            .HasData(

                new Customer
                {
                    Id = 1,
                    FirstName = "Ahmet",
                    LastName = "kartal",
                    RegionId = 1,
                    Salary = 10_000
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Burcu",
                    LastName = "Aslan",
                    RegionId = 2,
                    Salary = 12_000
                }
            );

            modelBuilder.Entity<Order>()
            .HasData(
                new Order
                {
                    Id = 1,
                    CustomerId = 1,
                    OrderDate = new DateTime(2022, 05, 15)
                },
                new Order
                {
                    Id = 2,
                    CustomerId = 1,
                    OrderDate = new DateTime(2022, 05, 15)
                },
                new Order
                {
                    Id = 3,
                    CustomerId = 2,
                    OrderDate = new DateTime(2022, 05, 16)
                },
                new Order
                {
                    Id = 4,
                    CustomerId = 2,
                    OrderDate = new DateTime(2022, 05, 16)
                }
            );

        }



    }
}