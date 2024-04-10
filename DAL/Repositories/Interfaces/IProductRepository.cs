using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Tools;

namespace DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        void Add(Product product);
        Task SaveChangesAsync();
    }
}
