using DAL.Data;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Category>> GetAllAsync() =>
            _context.Categories.ToListAsync();

        public Task<Category?> GetByIdAsync(int id) =>
            _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

    }
}