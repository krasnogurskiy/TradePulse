namespace DAL.Tools
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Product? Product { get; set; }
    }
}
