using BLL.DTOs;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trade_Pulse.Helpers;

namespace Trade_Pulse.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize(Roles = "Роздрібний покупець")]
        public async Task<IActionResult> Index()
        {
            var userId = this.GetAuthorizedUserId();
            var cartItems = await _cartService.GetCartItems(userId);
            return View(cartItems);
        }

        [Authorize(Roles = "Роздрібний покупець")]
        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(CartItemDto item)
        {
            var userId = this.GetAuthorizedUserId();
            if (ModelState.IsValid)
            {
                var result = await _cartService.AddToCart(item, userId);
                if (!result.IsSuccess) TempData["Error"] = result.Error!.Message;
            }
            return Redirect(HttpContext.Request.Headers["Referer"]!);
        }


        [Authorize(Roles = "Роздрібний покупець")]
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = this.GetAuthorizedUserId();
            await _cartService.RemoveFromCart(userId, id);
            return RedirectToAction("Index");
        }
    }
}
