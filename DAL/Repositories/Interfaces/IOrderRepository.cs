using DAL.Tools;


namespace DAL.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllAsync();
        public Task<List<Order>> GetVendorOrdersAsync(int userId);
        public Task<List<Order>> GetDropshipperOrdersAsync(int userId);
    }
}
