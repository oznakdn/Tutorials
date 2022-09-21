using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Linq_Keywords.Data
{
    public class AppDbContext:DbContext
    {

        string connectionString = @"Data Source = C:\Users\HP\OneDrive\Desktop\Tutorials\CSharp\Linq_Keywords\AppDB.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }

        public DbSet<Product>Products {get;set;}
        public DbSet<Category>Categories{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1, CategoryTitle = "Phone"}
            );

            modelBuilder.Entity<Product>().HasData(
                new Product {Id = 1, Brand = "Apple", Price = 25000, CategoryId =1},
                new Product {Id = 2, Brand = "Samsung", Price = 20000, CategoryId =1},
                new Product {Id = 3, Brand = "Huawei", Price = 15000, CategoryId =1}

            );
        }
    }
}