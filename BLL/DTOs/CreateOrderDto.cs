using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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
        //[Required(ErrorMessage = "Будь ласка, введіть адресу доставки")]
        //[DisplayName("Адреса доставки")]
        //[NotNull]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "Будь ласка, введіть область")]
        [DisplayName("Область")]
        [NotNull]
        public string Region { get; set; } = string.Empty;
        [Required(ErrorMessage = "Будь ласка, введіть населений пункт")]
        [DisplayName("Населений пункт")]
        [NotNull]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Будь ласка, вулицю, номер будинку і квартиру")]
        [DisplayName("Вулиця")]
        [NotNull]
        public string Street { get; set; } = string.Empty;
        [Required(ErrorMessage = "Будь ласка, вкажіть поштовий індекс")]
        [DisplayName("Поштовий індекс")]
        //[RegularExpression(@"^(\d{5})$", ErrorMessage = "Введіть валідний поштовий індекс")]
        [NotNull]
        public string PostalCode { get; set; } = string.Empty;
        //public int PostalCode { get; set; } 

    }
}
