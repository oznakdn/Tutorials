using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _04_QueryStructurs.Entities;
using Microsoft.EntityFrameworkCore;

namespace _04_QueryStructurs.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product>Products{get;set;}
        public DbSet<Category>Categories{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Data Source = AppDb.db");
            base.OnConfiguring(optionsBuilder);
        }

    }
}