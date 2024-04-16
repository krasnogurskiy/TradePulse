using DAL.Tools;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
	public class AppDbContext : IdentityDbContext<User, Role, int>
	{
        public AppDbContext() : base()
		{
		}
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<OrderProduct> OrdersProducts { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartProduct> CartsProducts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>()
				.Ignore(c => c.LockoutEnabled)
				.Ignore(c => c.LockoutEnd)
				.Ignore(c => c.AccessFailedCount).ToTable("Users");
			modelBuilder.Entity<Role>().ToTable("Roles");
		}
	}
}
