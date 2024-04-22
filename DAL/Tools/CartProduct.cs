using System.ComponentModel.DataAnnotations;

namespace DAL.Tools
{
    public class CartProduct
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public uint ItemsCount { get; set; }
    }
}
