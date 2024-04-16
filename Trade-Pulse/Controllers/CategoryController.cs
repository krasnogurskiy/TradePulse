using BLL.Services.Interfaces;
using DAL.Data;
using DAL.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Trade_Pulse.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //private readonly AppDbContext _context;
        //public CategoryController(AppDbContext context)
        //{
        //    _context = context;
        //}
        [Authorize]
        public IActionResult Index()
        {
	        List<Category> categories = _categoryService.GetAllAsync().Result;
	        return View("Category", categories);
            //List<Category> categories = _context.Categories.ToList(); ;
            //return View(categories);
        }
    }
}
