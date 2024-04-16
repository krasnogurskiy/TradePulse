using Microsoft.EntityFrameworkCore;

namespace DAL.Tools
{
    [Keyless]
    public class CartProduct
    {
        public Cart Cart { get; set; } = null!;
        public Cart Product { get; set; } = null!;
        public uint ItemsCount { get; set; }
    }
}
