using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos.ProductDtos;
using WebAPI.Services.Contracts;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _productService.GetProductsWithCategory();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var result = await _productService.GetProductById(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(string categoryId)
        {
            var result = await _productService.GetProductsByCategoryId(categoryId);
            return Ok(result);
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto model)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProduct(model);
                return Created("", model);
            }

            return BadRequest(HttpContext.Response.StatusCode);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductByCategory([FromBody] CreateProductWithByCategoryDto model)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProductWithByCategory(model);
                return Created("", model);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto model)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateProduct(model);
                return Ok(model);
            }

            return BadRequest(HttpContext.Response.ContentType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id is not null)
            {
                await _productService.DeleteProduct(id);
                return NoContent();
            }

            return NotFound();

        }
    }
}