namespace _17_EagerLoading.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; }
    }
}