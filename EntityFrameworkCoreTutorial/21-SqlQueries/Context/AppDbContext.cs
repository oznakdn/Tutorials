using _21_SqlQueries.Entities;
using Microsoft.EntityFrameworkCore;

namespace _21_SqlQueries.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:/Users/USER/Desktop/Yeni klasör/Tutorials/EntityFrameworkCoreTutorial/21-SqlQueries/AppDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
            .HasMany(x => x.Orders)
            .WithOne(x => x.Person)
            .HasForeignKey(x => x.PersonId);


            modelBuilder.Entity<Person>()
            .HasData(new Person
            {
                PersonId = 1,
                Name = "Ahmet",
            });

            modelBuilder.Entity<Order>()
            .HasData(

                new Order
                {
                    OrderId = 1,
                    PersonId = 1,
                    Description = "This is order1 description"
                },
                new Order
                {
                    OrderId = 2,
                    PersonId = 1,
                    Description = "This is order2 description"
                }
            );
        }
    }
}