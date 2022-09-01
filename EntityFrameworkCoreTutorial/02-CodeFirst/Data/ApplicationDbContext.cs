using _02_CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace _02_CodeFirst.Data
{
    public class ApplicationDbContext : DbContext
    {


        /// <summary>
        /// Veri tabanindaki tabloya karsilik gelir
        /// </summary>
        /// <value></value>
        public DbSet<Teacher> Teachers { get; set; }




        /// <summary>
        /// Kullanılacak veritabanını (ve diğer seçenekleri) yapılandırmak için kullanilir
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\USER\Desktop\EntityFrameworkCoreTutorial\02-CodeFirst\Teacher.db");
            
        }

    }
}