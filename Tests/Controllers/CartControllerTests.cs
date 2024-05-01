using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Features;
using BLL.Services.Interfaces;
using DAL.Tools;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Trade_Pulse.Controllers;
using Xunit;

namespace Tests.Controllers
{
    public class CartControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResult_WithCartItems()
        {
            // Arrange
            var userId = 123;
            var cartItems = new List<CartListItemDto>();
            var cartService = A.Fake<ICartService>();
            A.CallTo(() => cartService.GetCartItems(userId)).Returns(Task.FromResult(cartItems));
            var controller = new CartController(cartService);
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
            Assert.Equal(cartItems, result.Model);
        }

        [Fact]
        public async Task RemoveFromCart_WithValidId_RedirectsToIndex()
        {
            // Arrange
            var id = 1; // Sample cart item ID
            var userId = 123; // Sample user ID
            var cartService = A.Fake<ICartService>();
            var controller = new CartController(cartService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId.ToString()) }))
                }
            };

            // Act
            var result = await controller.RemoveFromCart(id) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }
    }
}
