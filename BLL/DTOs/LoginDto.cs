using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Введіть, будь ласка, електронну адресу")]
        [DisplayName("Електронна адреса")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Введіть, будь ласка, пароль")]
        [DisplayName("Пароль")]
        public string Password { get; set; } = string.Empty;
    }
}
