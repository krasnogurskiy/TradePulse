using BLL.Services.Interfaces;
using DAL.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Trade_Pulse.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
	        List<Category> categories = await _categoryService.GetAllAsync();
	        return View(categories);
        }
    }
}
