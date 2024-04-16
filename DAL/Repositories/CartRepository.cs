using DAL.Data;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task GetUsersCartAsync(int userId)
        {
            var cart = await _context.CartsProducts.Include((c) => c.Cart).Include((c) => c.Cart.User).Where((c) => c.Cart.User.Id == userId).Include((c) => c.Product).ToListAsync();
        }
    }
}
