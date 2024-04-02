namespace DAL.Tools
{
	public class Payment
	{
		public int Id { get; set; }
		public User From { get; set; } = null!;
		public User To { get; set; } = null!;
		public uint Amount { get; set; }
		public string Purpose { get; set; } = null!;

	}
}
