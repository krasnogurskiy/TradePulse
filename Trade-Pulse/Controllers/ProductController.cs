using System.Security.Claims;
using BLL.DTOs;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using Trade_Pulse.Helpers;
using Trade_Pulse.Models;
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace Trade_Pulse.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryRepository _categoryRepository;
        private IWebHostEnvironment Environment;


        public ProductController(IProductService productService, ICategoryRepository categoryRepository, IWebHostEnvironment environment)
        {
            _productService = productService;
            _categoryRepository = categoryRepository;
            Environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _productService.GetAllAsync();
            return View(products);
        }

        [Authorize(Roles = "Постачальник")]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var model = new CreateProductViewModel() { Categories = categories.ToArray() };
            return View(model);
        }

        [Authorize(Roles = "Постачальник")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel createProductDto)
        {
            var id = int.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            createProductDto.VendorId = id;
            if (!ModelState.IsValid) return View(createProductDto);
         
            var path = Path.Combine(this.Environment.WebRootPath, "img", "products");
            var saver = new FileSaver(path);
            if (createProductDto.MainImageFile != null) createProductDto.MainImage = await saver.SaveFileAsync(createProductDto.MainImageFile);
            createProductDto.Images = new List<string>();
            if (createProductDto.ImagesFiles != null) await Task.Run(() =>
            {
                foreach (IFormFile f in createProductDto.ImagesFiles!)
                {
                    var path = saver.SaveFile(f);
                    createProductDto.Images.Add(path);
                }
            });

            var result = await _productService.AddProductAsync(createProductDto);
            if (result.IsFailure)
            {
                TempData["Error"] = result.Error!.Message;
                return View(createProductDto);
            }

            return RedirectToAction("Index","Category");
        }

        public async Task<IActionResult> Product(int id)
        {
            List<Product> products = await _productService.GetAllByCategoryAsync(id);
            if (products == null || products.Count == 0)
            {
                return NotFound();
            }

            Category? category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                ViewBag.CategoryName = category.Title;
            }

            return View(products);
        }
    }
}