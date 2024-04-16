using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Tools;
using Microsoft.AspNetCore.Mvc;


namespace Trade_Pulse.Controllers
{
    public class ProductController : Controller
    {
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
		public IActionResult Index()
		{
			List<Product> products = _productService.GetAllAsync().Result;
			return View(products);
        }
		//Андрій
		public IActionResult Create()
		{
			return View();
		}

		public IActionResult Product(int id)
        {
			List<Product> products = _productService.GetAllByCategoryAsync(id).Result;
			//ViewBag.CategoryName = ...

			return View(products);


			//var category = _context.Categories.FirstOrDefault(c => c.Id == id);
			//if (category != null)
			//{
			//	ViewBag.CategoryName = category.Title;
			//	List<Product> productsInCategory = _context.Products.Where(p => p.Category != null && p.Category.Id == id).ToList();
			//	if (productsInCategory.Any())
			//	{
			//		return View(productsInCategory);
			//	}
			//}
			//return NotFound();
		}

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if (!ModelState.IsValid) return View(productDto);


            var result = await _productService.AddProductAsync(productDto);
            if (result.IsFailure)
            {
                TempData["Error"] = result.Error!.Message;
                return View(productDto);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}