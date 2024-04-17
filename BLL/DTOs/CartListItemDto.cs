namespace BLL.DTOs
{
    public class CartListItemDto : CartItemDto
    {
        public string ProductTitle { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
