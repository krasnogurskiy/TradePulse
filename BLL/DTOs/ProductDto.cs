using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Поле 'Назва товару' є обов'язковим")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле 'Ціна' є обов'язковим")]
        [Range(0, double.MaxValue, ErrorMessage = "Ціна повинна бути більше 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Поле 'Кількість' є обов'язковим")]
        [Range(1, int.MaxValue, ErrorMessage = "Кількість повинна бути більше 0")]
        public int Quantity { get; set; }

    }
}
