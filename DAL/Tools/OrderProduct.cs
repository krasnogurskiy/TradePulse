using Microsoft.EntityFrameworkCore;

namespace DAL.Tools
{
	[Keyless]
	public class OrderProduct
	{
		public Order Order { get; set; } = null!;
		public Product Product { get; set; } = null!;
		public uint ItemsCount { get; set; }
	}
}
