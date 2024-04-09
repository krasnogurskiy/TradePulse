using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.Tools;

namespace BLL.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<List<Product>> GetAllAsync()
		{
			var products = await _productRepository.GetAllAsync();

			return products;
		}

		public async Task<Product?> GetByIdAsync(int id)
		{
			var product = _productRepository.GetByIdAsync(id).Result;

			return product;
		}

		public async Task<List<Product>> GetAllByCategoryAsync(int category_id)
		{
			var product = await _productRepository.GetAllByCategoryAsync(category_id);

			return product;
		}
	}
}