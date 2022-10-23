namespace _09_EntityConfiguration.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}