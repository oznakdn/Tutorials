namespace WebAPI.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}