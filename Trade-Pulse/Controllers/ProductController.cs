using BLL.DTOs;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DAL.Repositories.Interfaces;
using System.Security.Claims;

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

    }
}