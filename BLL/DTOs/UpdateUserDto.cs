using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using DAL.Tools;

namespace BLL.DTOs
{
    public class UpdateUserDto
    {
        public UpdateUserDto()
        {

        }
        public UpdateUserDto(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            BirthDate = user.BirthDate;
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Обов'язкове поле")]
        [DisplayName("Ім'я")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Обов'язкове поле")]
        [DisplayName("Прізвище")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Обов'язкове поле")]
        [DisplayName("Дата народження")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
