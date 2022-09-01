namespace _06_RelationalTerms.Entities
{
    public class Employee
    {

        public Employee()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public bool Gender { get; set; }

        public int DepartmentId { get; set; }

        
        public Department Department { get; set; }
        public Contact Contact{get;set;}
        public ICollection<Project> Projects { get; set; }
    }
}