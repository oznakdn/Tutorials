using Microsoft.EntityFrameworkCore;
using MvcApp.Entity;

namespace MvcApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(product =>
            {
                product.Property(p => p.ProductName).HasMaxLength(200);
                product.Property(p => p.Color).HasMaxLength(50);
            });
        }


    }
}