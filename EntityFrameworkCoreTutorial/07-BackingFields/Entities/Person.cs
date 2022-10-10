using Microsoft.EntityFrameworkCore;

namespace _07_BackingFields.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string name;
        public string Name { get => name; set => name = value; }
        public string Department { get; set; }

    }

    // Attribute ile

    public class Employee
    {
        public int Id { get; set; }
        public string name;

        [BackingField(nameof(name))]
        public string Name { get => name; set => name = value; }
        public string Department { get; set; }
    }

}