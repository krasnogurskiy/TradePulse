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

        public async Task Add(Product product, int vendorId, int categoryId)
        {
            var vendor = new User() { Id = vendorId };
            var category = new Category() { Id = categoryId };
            _context.Users.Attach(vendor);
            _context.Categories.Attach(category);
            product.Vendor = vendor;
            product.Category = category;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

		//Юра
		public Task<List<Product>> GetAllByCategoryAsync(int category_id) =>
			_context.Products.Where(x => x.Category != null && x.Category.Id == category_id).ToListAsync();
	}
}