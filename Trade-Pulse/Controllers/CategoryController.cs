using DAL.Data;
using DAL.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Trade_Pulse.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context) {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList(); ;
            return View("Category", categories);
            //return View("Category");
        }
    }
}
