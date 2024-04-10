using System.ComponentModel.DataAnnotations;

namespace TradePulse.Models
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Поле назви обов'язкове")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле опису обов'язкове")]
        public string Description { get; set; }

        public string Model { get; set; }

        [Required(ErrorMessage = "Поле ціни обов'язкове")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Ціна повинна бути більше нуля")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Поле кількості товару обов'язкове")]
        [Range(1, uint.MaxValue, ErrorMessage = "Кількість товару повинна бути більше нуля")]
        public uint ItemsAvailable { get; set; }
    }
}
