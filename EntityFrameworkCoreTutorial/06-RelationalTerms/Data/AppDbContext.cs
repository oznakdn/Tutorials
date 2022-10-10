

namespace _06_RelationalTerms.Data
{
    using _06_RelationalTerms.Entities;
    using Microsoft.EntityFrameworkCore;
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = AppDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Employee>()
            .HasKey(x => x.Id);

            modelBuilder.Entity<Contact>()
            .HasKey(x => x.Id);

            modelBuilder.Entity<Department>()
            .HasKey(x => x.Id);

            modelBuilder.Entity<Project>()
            .HasKey(x => x.Id);



            /* Fluent Api ile configure edilebilen ozellikler

            Cascade Delete = Esas tablodan silinen veriyle bagli tabloda bulunan iliskili verilerin silinebilmesini saglar.
            SetNull  = Esas tablodan silinen veriyle bagli tabloda bulunan iliskili verilere null degerinin atanmasini saglar. OneToOne da kullanilmaz.
            Restrict = Esas tablodan veri silinmeye calisildiginda bagli tabloda iliskili veriler varsa silinebilmesini engeller.

            */

            // One To One
            modelBuilder.Entity<Contact>()
            .HasOne(c=>c.Employee).WithOne(e=>e.Contact)
            .OnDelete(DeleteBehavior.Restrict);

            // One To Many
            modelBuilder.Entity<Department>()
            .HasMany(x => x.Employees).WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);
            
            // Many To Many
            modelBuilder.Entity<Employee>()
            .HasMany(x => x.Projects).WithMany(x => x.Employees);

            modelBuilder.Entity<Project>()
            .HasMany(x => x.Employees).WithMany(x => x.Projects);

        }

    }
}