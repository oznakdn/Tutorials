using WebAPI.Entities;

namespace WebAPI.Dtos.CategoryDtos
{
    public class GetCategoyProductsDto
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}