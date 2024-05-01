using BLL.Services.Interfaces;
using DAL.Tools;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Trade_Pulse.Controllers;
using Moq;

namespace Tests.Controllers
{
    public class CategoryControllerTests
    {
        private readonly CategoryController _categoryController;
        private readonly ICategoryService _categoryService;

        public CategoryControllerTests()
        {
            _categoryService = A.Fake<ICategoryService>();

            _categoryController = new CategoryController(_categoryService);
        }

        [Fact]
        public async Task CategoryController_Index_ReturnsSuccess()
        {
            var categories = A.Fake<List<Category>>();
            A.CallTo(() => _categoryService.GetAllAsync()).Returns(categories);

            var result = await _categoryController.Index();

            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public async Task Index_ReturnsViewWithCategories()
        {
            // Arrange
            var mockCategoryService = new Mock<ICategoryService>();
            var expectedCategories = new List<Category>
            {
                new Category { Id = 1, Title = "Category 1" },
                new Category { Id = 2, Title = "Category 2" },
                new Category { Id = 3, Title = "Category 3" }
            };
            mockCategoryService.Setup(service => service.GetAllAsync()).ReturnsAsync(expectedCategories);
            var controller = new CategoryController(mockCategoryService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Category>>(viewResult.Model);
            Assert.Equal(expectedCategories, model);
        }

        [Fact]
        public async Task Index_ReturnsViewWithNoCategories()
        {
            // Arrange
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(service => service.GetAllAsync()).ReturnsAsync(new List<Category>());
            var controller = new CategoryController(mockCategoryService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Category>>(viewResult.Model);
            Assert.Empty(model);
        }
    }
}
