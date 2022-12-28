namespace _20_ComplexQueryOperators.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public string Description { get; set; }
        public Person Person { get; set; }
    }
}