namespace DAL.Tools
{
	public class Product
	{
		public int Id { get; set; }
		public Category Category { get; set; } = null!;
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string? Model { get; set; }
		public decimal Price { get; set; }
		public uint ItemsAvailable { get; set; }
		public DateTime CreatedAt { get; set; }
		public User Vendor { get; set; } = null!;
	}
}
