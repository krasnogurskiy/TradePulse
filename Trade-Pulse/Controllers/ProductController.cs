using BLL.Services.Interfaces;
using DAL.Data;
using DAL.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Trade_Pulse.Controllers
{
    public class ProductController : Controller
    {
        //private readonly IProductService _productService;
        private readonly AppDbContext _context;
		public ProductController(AppDbContext context)
		{
			_context = context;
		}
		//public ProductController(IProductService productService)
		//{
		//	_productService = productService;
		//}
		public IActionResult Index()
        {
			List<Product> products = _context.Products.ToList();
			//List<Product> products = _productService.GetAllAsync().Result;
            return View("Product", products);
        }

		public IActionResult Product(int id)
		{
			//List<Product> products = _productService.GetAllByCategoryAsync(category_id).Result;
			////var products = _productService.GetAllAsync().Result
			////	.Where(p => p.Category != null && p.Category.Id == category_id).ToList();
			////ViewBag.CategoryName = products.

			//return View(products);


			var category = _context.Categories.FirstOrDefault(c => c.Id == id);
			if (category != null)
			{
				ViewBag.CategoryName = category.Title;
				List<Product> productsInCategory = _context.Products.Where(p => p.Category != null && p.Category.Id == id).ToList();
				if (productsInCategory.Any())
				{
					return View(productsInCategory);
				}
			}
			return NotFound();
		}
	}
}