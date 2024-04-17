using BLL.Services;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Services
{
    public class CategoryServiceTest
    {
        [Fact]
        public async Task GetAllAsync_ReturnsListOfCategories()
        {
            // Arrange
            var fakeCategoryRepository = A.Fake<ICategoryRepository>();
            var categories = new List<Category>
            {
                new Category { Id = 1, Title = "Category 1", ImageFileName = "category1.jpg" },
                new Category { Id = 2, Title = "Category 2", ImageFileName = "category2.jpg" },
                new Category { Id = 3, Title = "Category 3", ImageFileName = "category3.jpg" }
            };
            A.CallTo(() => fakeCategoryRepository.GetAllAsync()).Returns(Task.FromResult(categories));
            var categoryService = new CategoryService(fakeCategoryRepository);

            // Act
            var result = await categoryService.GetAllAsync();

            // Assert
            Assert.Equal(categories, result);
        }

        //[Fact]
        //public async Task GetAllAsync_ReturnsEmptyList_WhenRepositoryReturnsNull()
        //{
        //    // Arrange
        //    var fakeCategoryRepository = A.Fake<ICategoryRepository>();
        //    A.CallTo(() => fakeCategoryRepository.GetAllAsync()).Returns(Task.FromResult<List<Category>>(null));
        //    var categoryService = new CategoryService(fakeCategoryRepository);

        //    // Act
        //    var result = await categoryService.GetAllAsync();

        //    // Assert
        //    Assert.Empty(result);
        //}
    }
}
