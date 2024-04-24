using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        [Required]
        [DisplayName("Кількість")]
        [Range(1, int.MaxValue, ErrorMessage = "Будь ласка, введіть додатне число")]
        public uint ItemsCount { get; set; }
    }
}
