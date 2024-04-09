using BLL.Services.Interfaces;
using DAL.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Trade_Pulse.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        //private readonly AppDbContext _context;
        //public CategoryController(AppDbContext context)
        //{
        //    _context = context;
        //}
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {

            //List<Category> categories = _context.Categories.ToList();
            List<Category> categories = _categoryService.GetAllAsync().Result;
            return View("Category", categories);
            //return View("Category");
        }
    }
}
