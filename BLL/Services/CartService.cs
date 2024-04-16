using BLL.DTOs;
using BLL.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class CartService : ICartService
    {
        private List<CartItemDto> _cartItems = new List<CartItemDto>();

        public void AddToCart(CartItemDto item)
        {
            var existingItem = _cartItems.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _cartItems.Add(item);
            }
        }

        public void RemoveFromCart(int productId)
        {
            _cartItems.RemoveAll(i => i.ProductId == productId);
        }

        public List<CartItemDto> GetCartItems()
        {
            return _cartItems;
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }
    }
}