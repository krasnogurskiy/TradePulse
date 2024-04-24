using BLL.DTOs;
using BLL.Features;
using DAL.Tools;

namespace BLL.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllAsync();
        public Task<IEnumerable<OrderDto>?> GetUserOrdersAsync(int userId);
        //public Task<List<Order>?> GetUserOrdersAsync(int userId);
        public Task<ServiceResult<int>> CreateOrderAsync(CreateOrderDto orderDto, int userId);
        public Task<ServiceResult<int>> UpdateOrderAsync(UpdateOrderDto updateOrderDto);
    }
}