using BLL.DTOs;
using DAL.Tools;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Interfaces
{
	public interface IProductService
	{
		public Task<List<Product>> GetAllAsync();
		public Task<Product?> GetByIdAsync(int id);
		public Task<List<Product>> GetAllByCategoryAsync(int category_id);
	}
}