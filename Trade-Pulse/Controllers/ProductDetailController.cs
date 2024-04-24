using BLL.DTOs;
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
        private readonly ICartService _cartService;

        public ProductDetailController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
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

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            //var product = _context.Products.FirstOrDefault(p => p.Id == id);
            //if (product != null)
            //{
            //    var cartItem = new CartItemDto
            //    {
            //        ProductId = product.Id,
            //        ProductTitle = product.Title,
            //        Price = product.Price,
            //        Quantity = 1
            //    };
            //    _cartService.AddToCart(cartItem);
            //    return RedirectToAction("Index", "Cart");
            //}
            return NotFound();
        }
    }
}
