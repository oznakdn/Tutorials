

/* Default Convertion
 * Bu iliski belirleme tipinde entity'lerdeki navigation property'lerden yararlanilir.
 * Asagidaki ornekte 
   - Student ve Address arasinda One To One bir iliski kurulmustur. Bir Student'in bir Address'i, bir Address'in bir Student'i olur.
   - Student ile School arasinda One To Many bir iliski kurulmustur. Bir Student'in bir School'u , bir School'un cok Student'i olur.
   - Student ile Lesson arasinda Many To Many bir iliski kurulmustur. Bir Student'in cok Lesson'u, bir Lesson'un cok Student'i olur.
*/
namespace _06_RelationalTerms.Terms
{
    public class DefaultConvertion
    {

    }

    public class Student
    {
        public int Id { get; set; } // PrimaryKey
        public string Name { get; set; }
        public int StudentNumber { get; set; }

        public int SchoolId { get; set; } // ForeignKey

        // Navigation Property
        public Address Address { get; set; }  // One To One relationship with Address
        public School School {get;set;}   // One To Many relationship with School
        public ICollection<Lesson> Lessons { get; set; } // Many To Many relationship with Lesson

    }

    public class Address
    {
        public int Id {get;set;} // PrimaryKey
        public string Street { get; set; }
        public string District { get; set; }

        // Address is dependent to Student
        public int StudentId { get; set; }  // ForeignKey


        // Navigation Property
        public Student Student {get;set;} 
    }

    public class School
    {
        public int Id { get; set; } // PrimaryKey
        public string SchoolName { get; set; }
        public string Address { get; set; }


        // Navigation Property
        public ICollection<Student>Students{get;set;} // One To Many relationship with Student

    }

    public class Lesson
    {
        public int Id { get; set; }
        public string LessonName { get; set; }


        // Navigation Property
        public ICollection<Student> Students { get; set; } // Many To Many relationship with Student
    }


}