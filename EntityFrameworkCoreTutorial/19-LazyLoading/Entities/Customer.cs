using Microsoft.EntityFrameworkCore.Infrastructure;

namespace _19_LazyLoading.Entities
{
    public class Customer
    {
        public Customer() { }

        private ILazyLoader _lazyLoader;
        private Region _region;
        public Customer(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }

        public virtual Region Region
        {
            get => _lazyLoader.Load(this, ref _region);

            set => _region = value;
        }
        public virtual ICollection<Order> Orders { get; set; }


    }
}