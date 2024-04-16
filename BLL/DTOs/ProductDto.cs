using DAL.Tools;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BLL.DTOs
{
    public class ProductDto
    {

        [Required(ErrorMessage = "Поле 'Категорія' є обов'язковим")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Поле 'Назва товару' є обов'язковим")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Поле 'Опис' є обов'язковим")]
        public string Description { get; set; } = null!;
        public string? Model { get; set; }

        [Required(ErrorMessage = "Поле 'Ціна' є обов'язковим")]
        [Range(0, double.MaxValue, ErrorMessage = "Ціна повинна бути більше 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Поле 'Кількість' є обов'язковим")]
        [Range(1, int.MaxValue, ErrorMessage = "Кількість повинна бути більше 0")]
        public uint ItemsAvailable { get; set; }
        public int VendorId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();

        public Category[] Categories { get; set; } = null!;

    }
}
