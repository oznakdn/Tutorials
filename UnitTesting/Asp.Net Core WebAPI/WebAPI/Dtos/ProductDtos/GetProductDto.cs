namespace WebAPI.Dtos.ProductDtos
{
    public class GetProductDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
    }
}