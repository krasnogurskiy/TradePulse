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
        public Task<Order?> GetByIdAsync(int orderId) =>
            _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

        public Task<List<Order>> GetVendorOrdersAsync(int userId) =>
            _context.Orders.Include(o => o.Product).ThenInclude(p => p.Vendor)
            .Where(v => v.Product.Vendor.Id == userId).Include(o => o.Receiver).ToListAsync();

        public Task<List<Order>> GetDropshipperOrdersAsync(int userId) =>
            _context.Orders.Include(o => o.Receiver)
            .Where(o => o.Receiver.Id == userId).Include(o => o.Product)
            .ThenInclude(p => p.Vendor).ToListAsync();

        public async Task CreateOrderAsync(Order order, int userId)
        {
            var receiver = new User() { Id = userId };
            _context.Users.Attach(receiver);
            order.Receiver = receiver;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}