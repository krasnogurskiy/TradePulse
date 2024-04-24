using BLL.Services.Interfaces;
using DAL.Data;
using DAL.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Trade_Pulse.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly IProductService _productService;

        public ProductDetailController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product != null)
            {
                return View("ProductDetail", product);
            }
            return NotFound();
        }
    }
}