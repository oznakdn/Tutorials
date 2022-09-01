/* Fluent Api
 * Bu iliski belirleme tipinde navigation property'ler tanimlandiktan Context sinifinda OnModelCreating metodu override edilerek iliskiler belirlenir.
*/


namespace _06_RelationalTerms.Terms
{

    using Microsoft.EntityFrameworkCore;
    public class FluentApi : DbContext
    {
        public DbSet<Okul> Okullar { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Adres> Adresler { get; set; }
        public DbSet<Telefon> Telefonlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ogrenci>().HasOne(x=>x.Adres).WithOne(x=>x.Ogrenci).HasForeignKey<Adres>(x=>x.Id); // One To One
            modelBuilder.Entity<Ogrenci>().HasOne(x=>x.Telefon).WithOne(x=>x.Ogrenci).HasForeignKey<Telefon>(x=>x.Id); // One To One
            modelBuilder.Entity<Ogrenci>().HasOne(x=>x.Okul).WithMany(x=>x.Ogrenciler).HasForeignKey(x=>x.Shl); // One To Many
            modelBuilder.Entity<Ogrenci>().HasMany(x=>x.Dersler).WithMany(x=>x.Ogrenciler); // Many To Mant
        }
    }
}