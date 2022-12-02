namespace _18_ExplicitLoading.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }

        public Region Region { get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}