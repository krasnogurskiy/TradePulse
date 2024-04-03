using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class SignUpDto
    {
        [EmailAddress]
        [Required(ErrorMessage = "Обов'язкове поле")]
        [DisplayName("Електронна адреса")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Обов'язкове поле")]
        [DisplayName("Ім'я")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Обов'язкове поле")]
        [DisplayName("Прізвище")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Обов'язкове поле")]
        [DisplayName("Роль")]
        public string Role { get; set; } = null!;

        [Required(ErrorMessage = "Обов'язкове поле")]
        [DisplayName("Дата народження")]
        public string BirthDate { get; set; } = "dd/mm/yy";
        [Required(ErrorMessage = "Обов'язкове поле")]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Обов'язкове поле")]
        [Compare("Password", ErrorMessage = "Паролі не збігаються")]
        [DataType(DataType.Password)]
        [DisplayName("Підтвердити пароль")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
