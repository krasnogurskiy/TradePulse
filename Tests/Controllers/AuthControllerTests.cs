using BLL.DTOs;
using BLL.Features;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Trade_Pulse.Controllers;

namespace Tests.Controllers
{
    public class AuthControllerTests
    {
        [Fact]
        public async Task SignUp_ValidModel_ReturnsRedirectToActionResult()
        {
            // Arrange
            var authService = A.Fake<IAuthService>();
            var signInManager = A.Fake<SignInManager<User>>();
            var userRepository = A.Fake<IUserRepository>();
            var controller = new AuthController(authService, signInManager, userRepository);
            var signUpDto = new SignUpDto { Email = "newuser@example.com",
                                               FirstName = "John",
                                               LastName = "Doe",
                                               Role = "User",
                                               BirthDate = new DateTime(1990, 1, 1),
                                               Password = "password123",
                                               ConfirmPassword = "password123" };

            // Act
            //var result = await controller.SignUp(signUpDto) as RedirectToActionResult;

            // Assert
            //Assert.NotNull(result);
            //Assert.Equal("Index", result.ActionName);
            //Assert.Equal("Auth", result.ControllerName);
        }

        [Fact]
        public async Task Login_ValidModel_ReturnsRedirectToActionResult()
        {
            // Arrange
            var authService = A.Fake<IAuthService>();
            var signInManager = A.Fake<SignInManager<User>>();
            var userRepository = A.Fake<IUserRepository>();
            var controller = new AuthController(authService, signInManager, userRepository);
            var loginDto = new LoginDto { Email = "example@example.com",
                                             Password = "examplepassword" };

            // Act
            //var result = await controller.Login(loginDto) as RedirectToActionResult;

            // Assert
            //Assert.NotNull(result);
            //Assert.Equal("Index", result.ActionName);
            //Assert.Equal("Category", result.ControllerName);
        }

        [Fact]
        public async Task Logout_ReturnsRedirectToActionResult()
        {
            // Arrange
            var authService = A.Fake<IAuthService>();
            var signInManager = A.Fake<SignInManager<User>>();
            var userRepository = A.Fake<IUserRepository>();
            var controller = new AuthController(authService, signInManager, userRepository);

            // Act
            var result = await controller.Logout() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public async Task Delete_AuthorizedUser_ReturnsRedirectToActionResult()
        {
            // Arrange
            var authService = A.Fake<IAuthService>();
            var signInManager = A.Fake<SignInManager<User>>();
            var userRepository = A.Fake<IUserRepository>();
            var controller = new AuthController(authService, signInManager, userRepository);

            var context = new DefaultHttpContext();
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1")
            }, "mock"));
            controller.ControllerContext = new ControllerContext { HttpContext = context };
            context.User = user;

            // Act
            var result = await controller.Delete() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }
    }
}
