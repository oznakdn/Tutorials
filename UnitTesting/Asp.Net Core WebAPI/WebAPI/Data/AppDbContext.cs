using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category)
                        .WithMany(c => c.Products)
                        .HasForeignKey(p => p.CategoryId);


            modelBuilder.Entity<Category>()
                        .HasData(
                            new Category { Id = new Guid("ca110d28-c66c-4eee-8e20-3576b9dd26d6"), CategoryName = "Phone" },
                            new Category { Id = new Guid("dbc6b8d8-d514-460c-9739-ce76eeeb6429"), CategoryName = "Notebook" }

                        );

            modelBuilder.Entity<Product>()
                        .HasData(
                            new Product
                            {
                                Id = new Guid("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7"),
                                ProductName = "Samsung",
                                CategoryId = new Guid("ca110d28-c66c-4eee-8e20-3576b9dd26d6"),
                                Price = 10000,
                                Stock = 10,
                                Color = "Silver"
                            },
                            new Product
                            {
                                Id = new Guid("054ab3c6-5604-4428-9587-852f6d7c8da4"),
                                ProductName = "Apple",
                                CategoryId = new Guid("ca110d28-c66c-4eee-8e20-3576b9dd26d6"),
                                Price = 20000,
                                Stock = 20,
                                Color = "Gold"
                            },
                            new Product
                            {
                                Id = new Guid("ed44afb2-3a9f-40f6-a3ff-ef76a1232348"),
                                ProductName = "Huawei",
                                CategoryId = new Guid("ca110d28-c66c-4eee-8e20-3576b9dd26d6"),
                                Price = 15000,
                                Stock = 30,
                                Color = "Black"
                            },
                            new Product
                            {
                                Id = new Guid("5f729da8-d97a-4eb7-bd38-9bbb6a593a9d"),
                                ProductName = "Macbook",
                                CategoryId = new Guid("dbc6b8d8-d514-460c-9739-ce76eeeb6429"),
                                Price = 15000,
                                Stock = 30,
                                Color = "Black"
                            });

            base.OnModelCreating(modelBuilder);
        }

    }
}