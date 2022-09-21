namespace Linq_Keywords
{
    public class Product
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public Category Category {get;set;}
    }
}