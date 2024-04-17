using System;
using FakeItEasy;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using DAL.Tools;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Trade_Pulse.Controllers;

namespace Tests.Controllers
{
    public class CategoryControllerTests
    {
        private CategoryController _categoryController;
        private ICategoryService _categoryService;
        public CategoryControllerTests()
        {
            _categoryService = A.Fake<ICategoryService>();

            _categoryController = new CategoryController(_categoryService);
        }

        [Fact]
        public void CategoryController_Index_ReturnsSuccess()
        {
            ////var categories = new List<Category>();
            ////var categories = A.Fake<List<Category>>();

            //var categories = A.Fake<IEnumerable<Category>>();

            //A.CallTo(() => _categoryService.GetAllAsync().Result).Returns(categories);

            //var result = _categoryController.Index();

            //result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
