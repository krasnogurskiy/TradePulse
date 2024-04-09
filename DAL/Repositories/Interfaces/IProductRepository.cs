using DAL.Tools;

namespace DAL.Repositories.Interfaces
{
	public interface IProductRepository
	{
		public Task<List<Product>> GetAllAsync();
		public Task<Product?> GetByIdAsync(int id);
		public Task<List<Product>> GetAllByCategoryAsync(int category_id);
	}
}
