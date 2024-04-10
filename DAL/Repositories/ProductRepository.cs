using System.Collections.Generic;
using System.Threading.Tasks;
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

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
