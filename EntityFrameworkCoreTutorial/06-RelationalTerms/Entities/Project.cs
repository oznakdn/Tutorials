namespace _06_RelationalTerms.Entities
{
    public class Project
    {

        public Project()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}