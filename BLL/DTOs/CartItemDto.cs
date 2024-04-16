using DAL.Tools;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
