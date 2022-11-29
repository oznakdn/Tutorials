namespace _17_EagerLoading.Entities
{
    public class Region
    {

        public Region()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string RegionName { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}