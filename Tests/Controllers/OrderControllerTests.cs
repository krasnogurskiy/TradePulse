using BLL.DTOs;
using BLL.Features;
using BLL.Services.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Trade_Pulse.Controllers;
using Xunit;

namespace Tests.Controllers
{
    public class OrderControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResultWithOrders()
        {
            // Arrange
            int userId = 123;
            var orders = new List<OrderDto>();
            var orderService = A.Fake<IOrderService>();
            A.CallTo(() => orderService.GetUserOrdersAsync(userId)).Returns(orders);
            var controller = new OrderController(orderService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId.ToString()) }))
                }
            };

            // Act
            var result = await controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.Equal(orders, result.Model);
        }

        [Fact]
        public async Task CreateOrder_WithValidModelState_CreatesOrderAndRedirectsToIndex()
        {
            // Arrange
            int userId = 123; // Sample user ID
            var createOrderDto = new CreateOrderDto();
            var resultDto = ServiceResult<int>.Success(1);
            var orderService = A.Fake<IOrderService>();
            A.CallTo(() => orderService.CreateOrderAsync(createOrderDto, userId)).Returns(resultDto);
            var controller = new OrderController(orderService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId.ToString()) }))
                }
            };

            // Act
            var result = await controller.CreateOrder(createOrderDto) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }
    }
}
