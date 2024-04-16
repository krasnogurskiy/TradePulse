using BLL.DTOs;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DAL.Repositories.Interfaces;
using System.Security.Claims;
using DAL.Tools;

namespace Trade_Pulse.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryRepository _categoryRepository;


        public ProductController(IProductService productService, ICategoryRepository categoryRepository)
        {
            _productService = productService;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            List<Product> products = _productService.GetAllAsync().Result;
            return View(products);
        }

        [Authorize(Roles = "Постачальник")]
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var model = new ProductDto() { Categories = categories.ToArray() };
            return View(model);
        }

        [Authorize(Roles = "Постачальник")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            var id = int.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            productDto.VendorId = id;
            if (!ModelState.IsValid) return View(productDto);

            var result = await _productService.AddProductAsync(productDto);
            if (result.IsFailure)
            {
                TempData["Error"] = result.Error!.Message;
                return View(productDto);
            }

            return RedirectToAction("Index", "Home");
        }
        public async Task <IActionResult> Product(int id)
        {
            List<Product> products = await _productService.GetAllByCategoryAsync(id);
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
    }
}