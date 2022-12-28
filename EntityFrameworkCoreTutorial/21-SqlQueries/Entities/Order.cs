namespace _21_SqlQueries.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public string Description { get; set; }
        public Person Person { get; set; }
    }
}