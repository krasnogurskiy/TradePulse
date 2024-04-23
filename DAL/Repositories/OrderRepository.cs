using DAL.Data;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Order>> GetAllAsync() =>
            _context.Orders.ToListAsync();

        public Task<List<Order>> GetVendorOrdersAsync(int userId) =>
            _context.Orders.Include(o => o.Product).ThenInclude(p => p.Vendor)
            .Where(v => v.Product.Vendor.Id == userId).ToListAsync();

        public Task<List<Order>> GetDropshipperOrdersAsync(int userId) =>
            _context.Orders.Include(o => o.Receiver).Where(o => o.Receiver.Id == userId).ToListAsync();

    }
}