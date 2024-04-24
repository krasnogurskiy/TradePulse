using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class CreateOrderDto : CartItemDto
    {
        [Required(ErrorMessage = "Будь ласка, введіть дроп ціну")]
        [DisplayName("Дроп ціна")]
        [Range(0, int.MaxValue, ErrorMessage = "Будь ласка, введіть додатне число")]
        public uint DropPrice { get; set; }
        [Required(ErrorMessage = "Будь ласка, виберіть тип доставки")]
        [DisplayName("Тип доставки")]
        public string DeliveryType { get; set; } = null!;
        [Required(ErrorMessage = "Будь ласка, виберіть тип оплати")]
        [DisplayName("Тип оплати")]
        public string PaymentType { get; set; } = null!;
        [Required(ErrorMessage = "Будь ласка, введіть адресу доставки")]
        [DisplayName("Адреса доставки")]
        public string Address { get; set; } = string.Empty;

    }
}
