using BLL.DTOs;
using BLL.Features;
using DAL.Tools;

namespace BLL.Services.Interfaces
{
    public interface ICartService
    {
        public Task<ServiceResult<int>> AddToCart(CartItemDto item, int userId);
        public Task RemoveFromCart(int userId, int productId);
        public Task<List<CartProduct>?> DeleteFromCart(int userId, int productId, bool save = false);
        public Task<List<CartListItemDto>> GetCartItems(int userId);
        public Task ClearCart(int userId);
    }
}