using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;
using WebAPI.Dtos.CategoryDtos;
using WebAPI.Services.Contracts;

namespace WebAPITests.ControllerTests
{
    public class CategoryControllerTests
    {
        private readonly Mock<ICategoryService> _moq;
        private readonly CategoriesController _categoriesController;

        private List<GetCategoriesDto> _categoriesDto;
        private GetCategoryDto _categoryDto;

        public CategoryControllerTests()
        {
            _moq = new Mock<ICategoryService>();
            _categoriesController = new CategoriesController(_moq.Object);
            _categoriesDto = new List<GetCategoriesDto>
            {
                new GetCategoriesDto { Id = "a56f6013-982d-4f65-ba4a-6a38ac075580", CategoryName = "Phone"},
                new GetCategoriesDto { Id = "81072ae5-2151-4367-ae78-896e6990b39b", CategoryName = "Notebook"},

            };

            _categoryDto = new GetCategoryDto
            {
                Id = "794b68ae-3056-4792-84f6-3ed0cc36070a",
                CategoryName = "Pc"
            };



        }


        #region GetCategories Action Tests

        [Fact]
        public async void GetCategories_ActionExecute_ReturnOkResultWithCategory()
        {

            _moq.Setup(p => p.GetCategories()).ReturnsAsync(_categoriesDto);

            var result = await _categoriesController.GetCategories();


            // Return Ok() control
            var returnResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, returnResult.StatusCode);

            // Return Ok(result) control
            var returnModel = Assert.IsAssignableFrom<List<GetCategoriesDto>>(returnResult.Value);

            // Count
            Assert.Equal<int>(2, returnModel.Count());

            // GetCategories method Execute control
            _moq.Verify(p => p.GetCategories(), Times.Once());
        }

        #endregion

        #region GetCategory Action Tests

        [Theory]
        [InlineData("test id")]
        public async void GetProduct_NotExistProduct_ReturnNotFoundWithMessage(string categoryId)
        {
            _categoryDto = null;
            _moq.Setup(p => p.GetCategory(categoryId)).ReturnsAsync(_categoryDto);
            var result = await _categoriesController.GetCategory(categoryId);

            var returnResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Category not found!", returnResult.Value);
            Assert.Equal(404, returnResult.StatusCode);


        }

        [Theory]
        [InlineData("794b68ae-3056-4792-84f6-3ed0cc36070a")]
        public async void GetProduct_ExistProduct_ReturnOkWithResult(string categoryId)
        {

            _moq.Setup(p => p.GetCategory(categoryId)).ReturnsAsync(_categoryDto);
            var result = await _categoriesController.GetCategory(categoryId);

            var returnResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, returnResult.StatusCode);
            var resturnModel = Assert.IsAssignableFrom<GetCategoryDto>(returnResult.Value);
            Assert.Equal(categoryId, resturnModel.Id);


        }
        #endregion

        #region Create Action Tests

        [Fact]
        public async void Create_When_ModelState_IsValid_ReturnCreatedResult()
        {
            CreateCategoryDto model = new();
            _moq.Setup(p => p.AddCategory(It.IsAny<CreateCategoryDto>())).ReturnsAsync(model);

            var result = await _categoriesController.Create(model);

            var returnResult = Assert.IsType<CreatedResult>(result);
            var returnModel = Assert.IsAssignableFrom<CreateCategoryDto>(returnResult.Value);
            _moq.Verify(p => p.AddCategory(model), Times.Once());
        }

        [Fact]
        public async void Create_When_ModelState_InValid_ReturnBadRequest()
        {
            CreateCategoryDto model = null;
            _categoriesController.ModelState.AddModelError("", "");

            // _categoriesController.ModelState.IsValid.Equals(false);

            _moq.Setup(p => p.AddCategory(It.IsAny<CreateCategoryDto>())).ReturnsAsync(model);

            var result = await _categoriesController.Create(model);

            var returnResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, returnResult.StatusCode);
            _moq.Verify(p => p.AddCategory(model), Times.Never());

        }

        #endregion

        #region Update Action Tests
        [Fact]
        public async void Update_When_ModelStateIsValid_ReturnCreatedAtActionResultWithModel()
        {
            // Arrange
            UpdateCategoryDto model = new();

            // Act

            _moq.Setup(p => p.UpdateCategory(It.IsAny<UpdateCategoryDto>())).ReturnsAsync(model);  // ICategoryService UpdateCategory  method

            var result = await _categoriesController.Update(model); // CategoriesController Update method

            // Assert

            var returnResult = Assert.IsType<CreatedAtActionResult>(result); // return CreatedAtAction()

            Assert.Equal(201, returnResult.StatusCode); // Http Status Code 201

            Assert.Equal("GetCategory", returnResult.ActionName); // return CreatedAtAction("GetCategory",)

            Assert.Equal(model.Id, returnResult.RouteValues.Values.Single());  // return CreatedAtAction("GetCategory", new {id = model.id})

            Assert.Equal(model, returnResult.Value);// return CreatedAtAction("GetCategory",model)

            _moq.Verify(p => p.UpdateCategory(It.IsAny<UpdateCategoryDto>()), Times.Once()); // Executed ICategoryService method
        }

        [Fact]
        public async void Update_When_ModelStateInValid_ReturnBadRequiestWithMessage()
        {
            UpdateCategoryDto model = new();

            _categoriesController.ModelState.AddModelError("", "");

            _moq.Setup(p => p.UpdateCategory(It.IsAny<UpdateCategoryDto>())).ReturnsAsync(model);

            var result = await _categoriesController.Update(model);

            var returnResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Information is invalid!", returnResult.Value);

            _moq.Verify(p => p.UpdateCategory(It.IsAny<UpdateCategoryDto>()), Times.Never());

        }
        #endregion

        #region Delete Action Tests
        [Theory]
        [InlineData("")]
        public async void Delete_When_ExecuteAction_ReturnNoContent(string categoryId)
        {
            _moq.Setup(p => p.DeleteCategory(categoryId));
            var result = await _categoriesController.Delete(categoryId);

            var returnResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, returnResult.StatusCode);
            _moq.Verify(p => p.DeleteCategory(categoryId), Times.Once());
        }

        #endregion

    }
}