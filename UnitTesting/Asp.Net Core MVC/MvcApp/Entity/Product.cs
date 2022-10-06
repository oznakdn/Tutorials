using System.ComponentModel.DataAnnotations;

namespace MvcApp.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string Color { get; set; }
    }
}