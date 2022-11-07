using AutoMapper;
using CourseApp.Shared.Results;
using MongoDB.Driver;
using Services.Catalog.Dtos.CategoryDtos;
using Services.Catalog.Models;
using Services.Catalog.Settings;

namespace Services.Catalog.Services
{
    public class CategoryService: ICategoryService
    {

        private readonly IMongoCollection<Category> categoryCollection;
        private readonly IMapper mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var dataBase = client.GetDatabase(databaseSettings.DatabaseName);
            categoryCollection = dataBase.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            this.mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await categoryCollection.Find(category => true).ToListAsync();
            var categoryDto = mapper.Map<List<CategoryDto>>(categories);
            return Response<List<CategoryDto>>.Success(categoryDto, 200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string categoryId)
        {
            Category category = await categoryCollection.Find<Category>(c => c.CategoryId == categoryId).FirstOrDefaultAsync();

            if (category is null)
            {
                return Response<CategoryDto>.Fail("Category not founf!", 404);
            }

            CategoryDto categoryDto = mapper.Map<CategoryDto>(category);

            return Response<CategoryDto>.Success(categoryDto, 200);
        }

        public async Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto createDto)
        {
            var category = mapper.Map<Category>(createDto);
            await categoryCollection.InsertOneAsync(category);
            var categoryDto = mapper.Map<CategoryDto>(category);

            return Response<CategoryDto>.Success(categoryDto, 200);
        }



    }
}
