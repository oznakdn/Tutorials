using _20_ComplexQueryOperators.Entities;
using Microsoft.EntityFrameworkCore;

namespace _20_ComplexQueryOperators.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Photo> Photos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:/Users/USER/Desktop/Yeni klasör/Tutorials/EntityFrameworkCoreTutorial/20-ComplexQueryOperators/AppDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>()
            .HasKey(x => x.PersonId);

            modelBuilder.Entity<Person>()
            .HasOne(x => x.Photo)
            .WithOne(x => x.Person);

            modelBuilder.Entity<Person>()
            .HasMany(x => x.Orders)
            .WithOne(x => x.Person)
            .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Person>()
            .HasData(
                new Person
                {
                    PersonId = 1,
                    Name = "Sedat",
                    Gender = Gender.Male
                },
                new Person
                {
                    PersonId = 2,
                    Name = "Burcu",
                    Gender = Gender.Female
                },
                new Person
                {
                    PersonId = 3,
                    Name = "Canan",
                    Gender = Gender.Female
                }
            );

            modelBuilder.Entity<Photo>()
            .HasData(
                new Photo
                {
                    PersonId = 1,
                    Url = "https://fotofoto.com/1"
                },
                new Photo
                {
                    PersonId = 2,
                    Url = "https://fotofoto.com/2"
                },
                new Photo
                {
                    PersonId = 3,
                    Url = "https://fotofoto.com/3"
                }
            );

            modelBuilder.Entity<Order>()
            .HasData(
                new Order
                {
                    OrderId = 1,
                    PersonId = 1,
                    Description = "This is Sedat's order."
                },
                 new Order
                 {
                     OrderId = 2,
                     PersonId = 2,
                     Description = "This is Burcu's order."
                 },
                 new Order
                 {
                     OrderId = 3,
                     PersonId = 3,
                     Description = "This is Canan's order."
                 }
            );
        }

    }
}