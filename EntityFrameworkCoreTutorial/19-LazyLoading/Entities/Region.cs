using Microsoft.EntityFrameworkCore.Infrastructure;

namespace _19_LazyLoading.Entities
{
    public class Region
    {

        public Region()
        {
            Customers = new HashSet<Customer>();
        }

        private ILazyLoader _lazyLoader;
        private ICollection<Customer> _customers;
        public Region(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public int Id { get; set; }
        public string RegionName { get; set; }

        public virtual ICollection<Customer> Customers
        {
            get => _lazyLoader.Load(this, ref _customers);
            set => _customers = value;

        }
    }
}