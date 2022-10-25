using _09_EntityConfiguration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _09_EntityConfiguration.EntityConfigurations
{

    // With Fluent API configuration

    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // Primary Key tanimlamak
            builder.HasKey(p => p.Id);

            // ForeignKey tanimlamak
            builder.HasOne(x => x.Department).WithMany(x => x.Persons).HasForeignKey(x => x.DepartmentId);


            // Colon isimlerini belirlemek
            builder.Property(p => p.Id).HasColumnName("Person ID");


            // Tabloda gorunmesi istenmeyen propery icin Ignore
            builder.Ignore(p => p.Description);

            /*Zorunlu alanlari tanimlamak
            builder.Property(x => new
            {
                x.DepartmentId,
                x.FirstName,
                x.LastName,
                x.Salary

            }).IsRequired();
            */


            // Colonun max karakter sayisini belirlemek
            builder.Property(p => p.LastName).HasMaxLength(30);

            // Kusuratli degerlerin noktadan sonraki hane sayisini belirleme (12.345)
            builder.Property(p => p.Salary).HasPrecision(5, 3);

            // Entity userinde aciklama yapmak istendiginde
            builder.Property(p => p.Salary).HasComment("Without Tax Gross Salary");

            // Uniq (benzersiz) alan tanimlamak icin
            builder.HasIndex(p => p.IdentityNumber).IsUnique();

            //Birden fazla alani PK yapmak icin kullanilir
            builder.HasKey("Id", "Id2");

            // Bir property'ye default deger vermek
            builder.Property(p => p.CreatedDate).HasDefaultValue<DateTime>(DateTime.Now);
            builder.Property(p => p.Salary).HasDefaultValue(5000);

            // Entity'deki birkac property kullanilarak, bir propery'e ait hesaplamalar yapmak. Onegin WorkingYear ve Salary uzerinden bonus hesaplamak
            builder.Property(p => p.Bonus).HasComputedColumnSql("[Salary]*[WorkingYear]*0.2");

            // Entity eklemek (data seeding) olusturmak
            builder.HasData(
                new Person
                {
                    IdentityNumber = 12345678901,
                    FirstName = "Mehmet",
                    LastName = "Kaplan",
                    WorkingYear = 5,
                    Salary = 10_000,
                    DepartmentId = 1
                }
            );


            // Bir entity'de PK alani olmasi istenmiyorsa
            builder.HasNoKey();

            // Belirli tablolara karsilik genel filtreler olusturmak
            builder.HasQueryFilter(p => p.IsActice == true);



        }
    }
}