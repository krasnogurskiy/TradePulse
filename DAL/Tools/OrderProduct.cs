using System.ComponentModel.DataAnnotations;

namespace DAL.Tools
{
    public class OrderProduct
	{
		[Key]
		public int Id { get; set; }
		public Order Order { get; set; } = null!;
		public Product Product { get; set; } = null!;
		public uint ItemsCount { get; set; }
	}
}
