using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _09_EntityConfiguration.Entities
{

    // With DataAnnotations configuration

    [Table("Persons")]
    public class Person
    {

        //[Key]
        //[Column("Person ID")]
        public int Id { get; set; }
        public int Id2 { get; set; }
        public long IdentityNumber { get; set; }

        //[Required]
        public string FirstName { get; set; }

        //[MaxLength(30)]
        public string LastName { get; set; }

        //[Precision(5, 3)]
        //[Comment("Without Tax Gross Salary")]

        public Decimal? Bonus { get; set; }
        public int WorkingYear { get; set; }
        public Decimal Salary { get; set; }
        public DateTime CreatedDate { get; set; }

        //[NotMapped]
        public string Description { get; set; }

        //[ForeignKey(nameof(Department))]
        //[Column("Department ID")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public bool IsActice { get; set; }
    }
}