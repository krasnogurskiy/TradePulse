using DAL.Tools;

namespace DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product?> GetByIdAsync(int id);
        public Task Add(Product product, int vendorId, int categoryId);
        public Task SaveChangesAsync();
    }
}
