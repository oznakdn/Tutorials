using Microsoft.EntityFrameworkCore.Infrastructure;

namespace _19_LazyLoading.Entities
{
    public class Order
    {

        public Order()
        {

        }
        private ILazyLoader _lazyLoader;
        private Customer _customer;
        public Order(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer
        {
            get => _lazyLoader.Load(this, ref _customer);
            set => _customer = value;

        }
    }
}