namespace _20_ComplexQueryOperators.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Photo Photo { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}