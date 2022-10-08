using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos.ProductDtos
{
    public class UpdateProductDto
    {

        [Required]
        public string Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string ProductName { get; set; }

        [Required]
        [Range(1, 1_000_000)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Color { get; set; }

        [Required]
        public string CategoryId { get; set; }
    }
}