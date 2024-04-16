using DAL.Tools;


namespace DAL.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllAsync();
    }
}
