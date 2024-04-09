using DAL.Data;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _context;
		public ProductRepository(AppDbContext context)
		{
			_context = context;
		}

		public Task<List<Product>> GetAllAsync() =>
			_context.Products.ToListAsync();

		public Task<Product?> GetByIdAsync(int id) =>
			_context.Products.FirstOrDefaultAsync(x => x.Id == id);

		public Task<List<Product>> GetAllByCategoryAsync(int category_id) =>
			_context.Products.Where(x => x.Category != null && x.Category.Id == category_id).ToListAsync();
	}
}