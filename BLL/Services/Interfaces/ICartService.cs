using BLL.DTOs;
using System.Collections.Generic;
using BLL.Errors;
using BLL.Features;
using DAL.Tools;

namespace BLL.Services.Interfaces
{
    public interface ICartService
    {
        void AddToCart(CartItemDto item);
        void RemoveFromCart(int productId);
        List<CartItemDto> GetCartItems();
        void ClearCart();
    }
}