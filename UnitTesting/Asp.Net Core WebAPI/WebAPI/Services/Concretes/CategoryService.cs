using WebAPI.Dtos.CategoryDtos;
using WebAPI.Entities;
using WebAPI.ExceptionHandler;
using WebAPI.Repositories.Contracts;
using WebAPI.Services.Contracts;

namespace WebAPI.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<List<GetCategoriesDto>> GetCategories()
        {
            var categories = categoryRepository.GetAll()
                             .Select(category => new GetCategoriesDto
                             {
                                 Id = category.Id.ToString(),
                                 CategoryName = category.CategoryName
                             }).ToList();

            return await Task.FromResult(categories);

        }

        public async Task<GetCategoryDto> GetCategory(string categoryId)
        {
            var category = await categoryRepository.GetByIdAsync(categoryId);
            GetCategoryDto categoryDto = new()
            {
                Id = category.Id.ToString(),
                CategoryName = category.CategoryName
            };

            return categoryDto;
        }

        public async Task<GetCategoyProductsDto> GetCategoyProducts(string categoryId)
        {

            var category = await categoryRepository.GetByIdAsync(categoryId, c => c.Products);

            if (category is null)
            {
                throw new NotFoundException("Category not found!");
            }
            GetCategoyProductsDto categoryDto = new()
            {
                Id = category.Id.ToString(),
                CategoryName = category.CategoryName,
                Products = category.Products.Select(p => new Product
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Stock = p.Stock,
                    Color = p.Color
                }).ToList()
            };

            return categoryDto;
        }

        public async Task<UpdateCategoryDto> UpdateCategory(UpdateCategoryDto model)
        {

            if (model is null)
            {
                throw new CustomException("Model is invalid!", model);
            }

            var category = await categoryRepository.GetByIdAsync(model.Id);

            category.CategoryName = model.CategoryName;
            await categoryRepository.UpdateAsync(category);
            return model;
        }

        public async Task<CreateCategoryDto> AddCategory(CreateCategoryDto model)
        {
            Category category = new()
            {
                CategoryName = model.CategoryName
            };

            await categoryRepository.AddAsync(category);
            return model;
        }

        public async Task DeleteCategory(string id)
        {
            if (id is null)
                throw new NotFoundException($"{id} Product Not Found!");

            else
                await categoryRepository.DeleteById(id);
        }
    }
}