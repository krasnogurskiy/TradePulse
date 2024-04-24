using DAL.Tools;


namespace DAL.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order?> GetByIdAsync(int orderId);
        public Task<List<Order>> GetAllAsync();
        public Task<List<Order>> GetVendorOrdersAsync(int userId);
        public Task<List<Order>> GetDropshipperOrdersAsync(int userId);
        public Task CreateOrderAsync(Order order, int userId);
        public Task UpdateOrderAsync(Order order);

    }
}
