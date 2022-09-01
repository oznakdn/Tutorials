namespace _06_RelationalTerms.Entities
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Employee> Employees { get; set; }
    }
}