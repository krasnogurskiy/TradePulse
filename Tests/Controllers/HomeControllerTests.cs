using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trade_Pulse.Controllers;
using Trade_Pulse.Models;

namespace Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_WhenUserAuthenticated_RedirectsToCategoryIndex()
        {
            // Arrange
            var controller = new HomeController();
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = Mock.Of<HttpContext>(x => x.User.Identity.IsAuthenticated == true)
            };

            // Act
            var result = controller.Index() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Category", result.ControllerName);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Index_WhenUserNotAuthenticated_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController();
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = Mock.Of<HttpContext>(x => x.User.Identity.IsAuthenticated == false)
            };

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Error_ReturnsViewResultWithErrorViewModel()
        {
            // Arrange
            var controller = new HomeController();
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            // Act
            var result = controller.Error() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ErrorViewModel>(result.Model);
        }
    }
}