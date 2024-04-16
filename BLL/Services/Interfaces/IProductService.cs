using BLL.DTOs;
using BLL.Features;
using DAL.Tools;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Interfaces
{
	public interface IProductService
	{
		//Юра
		public Task<List<Product>> GetAllAsync();
		public Task<Product?> GetByIdAsync(int id);
		public Task<List<Product>> GetAllByCategoryAsync(int category_id);

		//Андрій
        //public Task AddProductAsync(ProductDto productDto);
        Task<ServiceResult<ProductDto>> AddProductAsync(ProductDto productDto);

	}
}