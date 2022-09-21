namespace Linq_Keywords
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryTitle { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        
    }
}