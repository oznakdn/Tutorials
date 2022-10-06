using Microsoft.AspNetCore.Mvc;
using MvcApp.Entity;
using MvcApp.Repository.Contacts;

namespace MvcApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;


        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product is null) return NotFound();
            return View(product);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var updatedProduct = await _productRepository.GetByIdAsync(id);
            if (updatedProduct is null) return NotFound();

            var product = new Product
            {
                ProductName = updatedProduct.ProductName,
                Price = updatedProduct.Price,
                Stock = updatedProduct.Stock,
                Color = updatedProduct.Color
            };
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(product);
                return RedirectToAction(nameof(Details), new { id = product.Id });
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var product = await _productRepository.GetByIdAsync(id);

            if (product is null) return NotFound();

            _productRepository.Delete(product);
            return RedirectToAction(nameof(Index));
        }




    }
}