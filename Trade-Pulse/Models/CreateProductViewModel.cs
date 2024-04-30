using BLL.DTOs;
using Trade_Pulse.Attributes;

namespace Trade_Pulse.Models
{
    public class CreateProductViewModel : ProductDto
    {
        [MaxFileSize(1024 * 1024, ErrorMessage = "Файл занадто великий")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = "Файл не є картинкою")]
        public IFormFile? MainImageFile { get; set; }
        [FileList(5 * 1024 * 1024, new string[] { ".jpg", ".jpeg", ".png" }, 5)]
        public List<IFormFile>? ImagesFiles { get; set; }
    }
}
