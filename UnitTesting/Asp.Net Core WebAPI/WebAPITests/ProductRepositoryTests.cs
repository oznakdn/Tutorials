using Moq;
using WebAPI.Entities;
using WebAPI.Repositories.Contracts;

namespace WebAPITests
{
    public class ProductRepositoryTests
    {

        private readonly Mock<IProductRepository> _moqRepository;
        private List<Product> _products;
        private List<Category> _categories;
        public ProductRepositoryTests()
        {
            _moqRepository = new Mock<IProductRepository>();

            _categories = new List<Category>
             {
                 new Category {Id=new Guid("27dccd70-8dba-4573-bae0-8f33d3322127"), CategoryName = "Phone"},
                 new Category {Id=new Guid("dbc6b8d8-d514-460c-9739-ce76eeeb6429"), CategoryName = "Notebook"}

             };
            _products = new List<Product>
            {
                new Product {Id = new Guid("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7"),
                             ProductName = "Samsung",
                             CategoryId=new Guid("27dccd70-8dba-4573-bae0-8f33d3322127"),
                             Price = 10000, Stock=10,
                             Color = "Silver"},
                new Product {Id = new Guid("054ab3c6-5604-4428-9587-852f6d7c8da4"),
                             ProductName = "Apple",
                             CategoryId=new Guid("27dccd70-8dba-4573-bae0-8f33d3322127"),
                             Price = 20000, Stock=20,
                             Color = "Gold"},
                new Product {Id = new Guid("ed44afb2-3a9f-40f6-a3ff-ef76a1232348"),
                             ProductName = "Huawei",
                             CategoryId=new Guid("27dccd70-8dba-4573-bae0-8f33d3322127"),
                             Price = 15000,
                             Stock=30,
                             Color = "Black"},
                new Product {Id = new Guid("5f729da8-d97a-4eb7-bd38-9bbb6a593a9d"),
                             ProductName = "Macbook",
                             CategoryId=new Guid("dbc6b8d8-d514-460c-9739-ce76eeeb6429"),
                             Price = 15000,
                             Stock=30,
                             Color = "Black"}
            };
        }


        [Fact]
        public void GetAll_When_PredicateIsNull_ReturnQueryableProducts()
        {
            var products = _products.AsQueryable<Product>();

            _moqRepository.Setup(p => p.GetAll(null)).Returns(() => products);
        }

        [Theory]
        [InlineData('a')]

        public void GetAll_When_PredicateIsNotNull_ReturnQuerableProducts(char isContains)
        {
            var products = _products.Where(x => x.ProductName.Contains(isContains)).AsQueryable();
            _moqRepository.Setup(p => p.GetAll(x => x.ProductName.Contains(isContains))).Returns(() => products);
        }

        [Fact]
        public void GetAllAsync_When_PredicateIsNull_ReturnProducts()
        {
            var products = _products.ToList();
            _moqRepository.Setup(p => p.GetAllAsync(null)).ReturnsAsync(() => products);

        }

        [Theory]
        [InlineData("27dccd70-8dba-4573-bae0-8f33d3322127")]
        public void GetAllAsync_When_PredicateIsNotNull_ReturnProducts(Guid categoryId)
        {
            var products = _products.Where(x => x.CategoryId == categoryId).ToList();
            _moqRepository.Setup(p => p.GetAllAsync(x => x.CategoryId == categoryId)).ReturnsAsync(() => products);

        }

        [Fact]
        public void GetAllWithInclude_When_PredicateAndIncludeIsNull_ReturnIEnumerableProducts()
        {
            var products = _products.ToList();
            _moqRepository.Setup(p => p.GetAllWithInclude(null, null)).Returns(() => products);
        }

        [Theory]
        [InlineData("27dccd70-8dba-4573-bae0-8f33d3322127")]
        public void GetAllWithInclude_When_PredicateAndIncludeIsNotNull_ReturnIEnumerableProductsWithCategory(Guid categoryId)
        {
            var products = (from p in _products
                            join c in _categories
                            on p.CategoryId equals c.Id
                            where (p.CategoryId == categoryId)
                            select new Product
                            {
                                Id = p.Id,
                                ProductName = p.ProductName,
                                Price = p.Price,
                                Stock = p.Stock,
                                Color = p.Color,
                                CategoryId = c.Id
                            }).ToList();

            _moqRepository.Setup(p => p.GetAllWithInclude(x => x.CategoryId == categoryId, x => x.Category)).Returns(() => products);

        }

        [Theory]
        [InlineData("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7")]
        public void GetAsync_When_NotNullPredicate_ReturnProduct(Guid productId)
        {
            var product = _products.Where(x => x.Id == productId).Single();
            _moqRepository.Setup(p => p.GetAsync(x => x.Id == productId)).ReturnsAsync(() => product);
        }

        [Theory]
        [InlineData("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7")]
        public void GetByIdAsync_When_NotNullPredicateAndNullInclude_ReturnProduct(Guid productId)
        {
            string id = productId.ToString();
            var product = _products.Where(x => x.Id == Guid.Parse(id)).Single();
            _moqRepository.Setup(p => p.GetByIdAsync(id, null)).ReturnsAsync(product);
        }

        [Theory]
        [InlineData("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7")]
        public void GetByIdAsync_When_NotNullPredicateAndInclude_ReturnProduct(Guid productId)
        {
            string id = productId.ToString();
            var product = (from p in _products
                           join c in _categories
                           on p.CategoryId equals c.Id
                           where (p.Id == productId)
                           select new Product
                           {
                               Id = p.Id,
                               ProductName = p.ProductName,
                               Price = p.Price,
                               Stock = p.Stock,
                               Color = p.Color,
                               CategoryId = c.Id
                           }).Single();

            _moqRepository.Setup(p => p.GetByIdAsync(id, x => x.Category)).ReturnsAsync(product);

        }

        [Fact]
        public void AddAsync_When_ExecuteMethod_ReturnProduct()
        {
            Product product = new();
            _moqRepository.Setup(p => p.AddAsync(It.IsAny<Product>())).ReturnsAsync(product);

        }

        [Fact]
        public void UpdateAsync_When_ExecuteMethod_ReturnProduct()
        {
            Product product = new();
            _moqRepository.Setup(p => p.UpdateAsync(It.IsAny<Product>())).ReturnsAsync(product);

        }

        [Fact]
        public void DeleteAsync_When_ExecuteMethod_ReturnProduct()
        {
            _moqRepository.Setup(p => p.DeleteAsync(It.IsAny<Product>()));

        }

        [Theory]
        [InlineData("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7")]
        public void DeleteById_When_ExecuteMethod_ReturnProduct(Guid productId)
        {
            var id = productId.ToString();
            _moqRepository.Setup(p => p.DeleteById(id));

        }





    }
}