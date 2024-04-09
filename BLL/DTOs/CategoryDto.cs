using DAL.Tools;

namespace BLL.DTOs
{
    public class CategoryDto
    {
        public CategoryDto(Category category)
        {
            Id = category.Id;
            Title = category.Title;
        }
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
