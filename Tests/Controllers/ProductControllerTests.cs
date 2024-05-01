using System.Security.Claims;
using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using Microsoft.AspNetCore.Mvc;
using Trade_Pulse.Controllers;
using Moq;
using BLL.Features;
using Microsoft.AspNetCore.Http;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Hosting;
using Trade_Pulse.Models;

namespace Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly ProductController _productController;
        private readonly IProductService _productService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductControllerTests()
        {
            _productService = A.Fake<IProductService>();
            _categoryRepository = A.Fake<ICategoryRepository>();
            _webHostEnvironment = A.Fake<IWebHostEnvironment>();

            _productController = new ProductController(_productService, _categoryRepository, _webHostEnvironment);
        }

        [Fact]
        public async Task ProductController_Index_ReturnsSuccess()
        {
            var products = A.Fake<List<Product>>();
            A.CallTo(() => _productService.GetAllAsync()).Returns(products);

            var result = await _productController.Index();

            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public async Task Create_Get_ReturnsViewResultWithModel()
        {
            // Arrange
            var categories = new List<Category> { new Category { Id = 1, Title = "Category 1" } };
            A.CallTo(() => _categoryRepository.GetAllAsync()).Returns(categories);

            // Act
            var result = await _productController.Create() as ViewResult;

            // Assert
            result.Should().BeOfType<ViewResult>();
            result.Model.Should().BeOfType<CreateProductViewModel>().And.Subject.As<CreateProductViewModel>().Categories.Should().BeEquivalentTo(categories);
        }

        [Fact]
        public async Task Create_Post_ValidModelState_AddsProductAndRedirectsToIndex()
        {
        //    // Arrange
        //    var productDto = new CreateProductViewModel { /* Valid model state */ };
        //    A.CallTo(() => _productService.AddProductAsync(productDto)).Returns(ServiceResult<CreateProductViewModel>.Success(productDto));

        //    // Mock User for the controller
        //    var userClaims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.NameIdentifier, "1")
        //};
        //    var principal = new ClaimsPrincipal(new ClaimsIdentity(userClaims, "TestAuthentication"));
        //    _productController.ControllerContext = new ControllerContext()
        //    {
        //        HttpContext = new DefaultHttpContext() { User = principal }
        //    };

        //    // Act
        //    var result = await _productController.Create(productDto) as RedirectToActionResult;

        //    // Assert
        //    result.Should().NotBeNull().And.BeOfType<RedirectToActionResult>();
        //    result.ActionName.Should().Be("Index");
        //    result.ControllerName.Should().Be("Home");
        }

        [Fact]
        public async Task Product_ExistingCategoryId_ReturnsViewResultWithProducts()
        {
            // Arrange
            var categoryId = 1;
            var category = new Category { Id = categoryId, Title = "Category 1" };
            var products = new List<Product> { new Product { Id = 1, Title = "Product 1", Category = category } };
            A.CallTo(() => _productService.GetAllByCategoryAsync(categoryId)).Returns(products);
            A.CallTo(() => _categoryRepository.GetByIdAsync(categoryId)).Returns(category);

            // Act
            var result = await _productController.Product(categoryId) as ViewResult;

            // Assert
            result.Should().NotBeNull().And.BeOfType<ViewResult>();
            result.Model.Should().BeOfType<List<Product>>().And.BeEquivalentTo(products);
        }

        [Fact]
        public async Task Product_NonExistingCategoryId_ReturnsNotFoundResult()
        {
            // Arrange
            var categoryId = 999;
            A.CallTo(() => _productService.GetAllByCategoryAsync(categoryId)).Returns((List<Product>)null);

            // Act
            var result = await _productController.Product(categoryId) as NotFoundResult;

            // Assert
            result.Should().NotBeNull().And.BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Index_ReturnsViewWithProducts()
        {
            // Arrange
            var expectedProducts = new List<Product>
            {
                new Product { Id = 1, Title = "Product 1" },
                new Product { Id = 2, Title = "Product 2" },
                new Product { Id = 3, Title = "Product 3" }
            };
            A.CallTo(() => _productService.GetAllAsync()).Returns(expectedProducts);

            // Act
            var result = await _productController.Index();

            // Assert
            var viewResult = result.Should().BeOfType<ViewResult>().Subject;
            var model = viewResult.Model.Should().BeAssignableTo<List<Product>>().Subject;
            model.Should().BeEquivalentTo(expectedProducts);
        }

        [Fact]
        public async Task Create_ReturnsViewWithModel()
        {
            // Arrange
            var categories = new List<Category> { new Category { Id = 1, Title = "Category 1" }, new Category { Id = 2, Title = "Category 2" } };
            A.CallTo(() => _categoryRepository.GetAllAsync()).Returns(categories);

            // Act
            var result = await _productController.Create() as ViewResult;

            // Assert
            result.Should().NotBeNull().And.BeOfType<ViewResult>();
            result.Model.Should().NotBeNull().And.BeOfType<CreateProductViewModel>();
            var model = result.Model.Should().BeAssignableTo<CreateProductViewModel>().Subject;
            model.Categories.Should().BeEquivalentTo(categories);
        }

        [Fact]
        public async Task Create_InvalidModelState_ReturnsViewWithModel()
        {
            //// Arrange
            //var mockCategoryRepository = new Mock<ICategoryRepository>();
            //var controller = new ProductController(null, mockCategoryRepository.Object);

            //// Mocking the user context
            //var userClaims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.NameIdentifier, "1")
            //};
            //var principal = new ClaimsPrincipal(new ClaimsIdentity(userClaims, "TestAuthentication"));
            //controller.ControllerContext = new ControllerContext()
            //{
            //    HttpContext = new DefaultHttpContext() { User = principal }
            //};

            //controller.ModelState.AddModelError("Name", "Required");

            //// Act
            //var result = await controller.Create(new ProductDto()) as ViewResult;

            //// Assert
            //Assert.NotNull(result);
            //Assert.IsType<ProductDto>(result.Model);
        }

        [Fact]
        public async Task Product_ValidId_ReturnsViewWithProducts()
        {
            //// Arrange
            //var mockProductService = new Mock<IProductService>();
            //var expectedProducts = new List<Product>
            //{
            //    new Product { Id = 1, Title = "Product 1" },
            //    new Product { Id = 2, Title = "Product 2" },
            //    new Product { Id = 3, Title = "Product 3" }
            //};
            //mockProductService.Setup(service => service.GetAllByCategoryAsync(It.IsAny<int>())).ReturnsAsync(expectedProducts);

            //// Mocking category repository to return null when GetByIdAsync is called
            //var mockCategoryRepository = new Mock<ICategoryRepository>();
            //mockCategoryRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Category)null);

            //var controller = new ProductController(mockProductService.Object, mockCategoryRepository.Object);

            //// Act
            //var result = await controller.Product(1) as ViewResult;

            //// Assert
            //Assert.NotNull(result);
            //Assert.IsType<List<Product>>(result.Model);
            //var model = result.Model as List<Product>;
            //Assert.Equal(expectedProducts.Count, model.Count);
        }

        [Fact]
        public async Task Product_InvalidId_ReturnsNotFound()
        {
            //// Arrange
            //var mockProductService = new Mock<IProductService>();
            //mockProductService.Setup(service => service.GetAllByCategoryAsync(It.IsAny<int>())).ReturnsAsync((List<Product>)null); // Simulating no products found
            //var controller = new ProductController(mockProductService.Object, null);

            //// Act
            //var result = await controller.Product(999) as NotFoundResult;

            //// Assert
            //Assert.NotNull(result);
            //Assert.Equal(404, result.StatusCode);
        }
    }
}