using Microsoft.AspNetCore.Identity;

namespace DAL.Tools
{
	public class User : IdentityUser<int>
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public DateTime BirthDate { get; set; }
		public DateTime CreatedAt { get; set; }
		public List<Order>? Orders { get; set; }
		public List<Product>? Products { get; set; }
		public Subscription? Subscription { get; set; } = null!;
	}
}