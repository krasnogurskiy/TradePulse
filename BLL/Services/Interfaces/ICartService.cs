using BLL.DTOs;
using BLL.Features;

namespace BLL.Services.Interfaces
{
    public interface ICartService
    {
        public Task<ServiceResult<int>> AddToCart(CartItemDto item, int userId);
        public Task RemoveFromCart(int userId, int productId);
        public Task<List<CartListItemDto>> GetCartItems(int userId);
        public Task ClearCart(int userId);
    }
}