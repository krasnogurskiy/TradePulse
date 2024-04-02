namespace DAL.Tools
{
    public class Subscription
    {
        public int Id { get; set; }
        public uint Price { get; set; }
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public uint AllowedItemsCount { get; set; }
        public TimeSpan Term { get; set; }
    }
}
