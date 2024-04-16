using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Tools;

namespace DAL.Repositories.Interfaces
{
	public interface IProductRepository
	{
		//Юра
		public Task<List<Product>> GetAllAsync();
		public Task<Product?> GetByIdAsync(int id); //спільне
		public Task<List<Product>> GetAllByCategoryAsync(int category_id);

		//Андрій
        Task<List<Product>> GetAllAsync();
        void Add(Product product);
        Task SaveChangesAsync();
	}
}
