namespace _21_SqlQueries.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}