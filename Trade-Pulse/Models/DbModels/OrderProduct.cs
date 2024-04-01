using Microsoft.EntityFrameworkCore;

namespace Trade_Pulse.Models.DbModels
{
	[Keyless]
	public class OrderProduct
	{
		public Order Order { get; set; } = null!;
		public Product Product { get; set; } = null!;
		public uint ItemsCount { get; set; }
	}
}
