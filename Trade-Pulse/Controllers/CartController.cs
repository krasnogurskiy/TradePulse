using BLL.Services.Interfaces;
using DAL.Data;
using DAL.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Trade_Pulse.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems();
            return View(cartItems);
        }

        public IActionResult AddToCart(int id)
        {
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
