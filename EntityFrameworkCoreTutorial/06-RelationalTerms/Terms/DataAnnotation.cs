/* Data Annotations
 * Bu iliski belirleme tipinde navigation property'ler tanimlandiktan sonra DataAnnotation attribute'lerden yararlanilir.
 * Asagidaki ornekte 
   - PrimaryKey icin [Key] attribute kullanilmistir
   - ForeignKey icin [ForeignKey("")] attribute kullanilmistir
   - PrimaryKey ve ForeignKey yapmak icin [Key, ForeignKey("")] attribute kullanilmistir. (Ogrenci - telefon) bagimli entity'nin Id'si hem PK hem de FK yapilabilir.
*/


namespace _06_RelationalTerms.Terms
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DataAnnotation
    {

    }

    public class Ogrenci
    {
        [Key]
        public int Id { get; set; } // PrimaryKey
        public string Name { get; set; }
        public int StudentNumber { get; set; }


        [ForeignKey(nameof(Okul))]
        public int Shl { get; set; } // ForeignKey

        // Navigation Property
        public Adres Adres { get; set; }  // One To One relationship with Address
        public Telefon Telefon { get; set; } // One To One relationship with Phone
        public Okul Okul { get; set; }   // One To Many relationship with School
        public ICollection<Ders> Dersler { get; set; } // Many To Many relationship with Lesson

    }

    public class Adres
    {
        [Key]
        public int Id { get; set; } // PrimaryKey
        public string Street { get; set; }
        public string District { get; set; }

        // Address is dependent to Student
        [ForeignKey(nameof(Ogrenci))]
        public int Std { get; set; }  // ForeignKey


        // Navigation Property
        public Ogrenci Ogrenci { get; set; }

    }

    public class Telefon
    {
        [Key, ForeignKey(nameof(Ogrenci))]
        public int Id { get; set; } // PrimaryKey,ForeignKey
        public string PhoneNumber { get; set; }
        public Ogrenci Ogrenci { get; set; }
    }

    public class Okul
    {
        [Key]
        public int Id { get; set; } // PrimaryKey
        public string SchoolName { get; set; }
        public string Address { get; set; }


        // Navigation Property
        public ICollection<Ogrenci> Ogrenciler { get; set; } // One To Many relationship with Student

    }

    public class Ders
    {
        [Key]
        public int Id { get; set; }
        public string LessonName { get; set; }


        // Navigation Property
        public ICollection<Ogrenci> Ogrenciler { get; set; } // Many To Many relationship with Student
    }
}