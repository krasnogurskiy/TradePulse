using BLL.Services.Interfaces;
using DAL.Data;
using DAL.Tools;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trade_Pulse.Controllers;

namespace Tests.Controllers
{
    public class ProductDetailControllerTests
    {
        [Fact]
        public async Task Index_ValidId_ReturnsViewWithProduct()
        {
            // Arrange
            int productId = 1;
            var expectedProduct = new Product { Id = productId, Title = "Product 1" };
            var productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.GetByIdAsync(productId)).ReturnsAsync(expectedProduct);
            var controller = new ProductDetailController(productServiceMock.Object);

            // Act
            var result = await controller.Index(productId) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ProductDetail", result.ViewName);
            var model = Assert.IsType<Product>(result.Model);
            Assert.Equal(productId, model.Id);
            Assert.Equal("Product 1", model.Title);
        }

        [Fact]
        public async Task Index_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidProductId = 999;
            var productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.GetByIdAsync(invalidProductId)).ReturnsAsync((Product)null);
            var controller = new ProductDetailController(productServiceMock.Object);

            // Act
            var result = await controller.Index(invalidProductId) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}
