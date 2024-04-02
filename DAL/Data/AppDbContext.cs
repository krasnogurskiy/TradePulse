using DAL.Tools;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext() : base()
		{
		}
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<OrderProduct> OrdersProducts { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Role> Roles { get; set; }
	}
}
