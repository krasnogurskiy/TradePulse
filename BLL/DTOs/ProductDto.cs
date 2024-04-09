using DAL.Tools;

namespace BLL.DTOs
{
	public class ProductDto
	{
		public ProductDto(Product product)
		{
			Id = product.Id;
			Title = product.Title;
		}
		public int Id { get; set; }
		public Category Category { get; set; }
		public string Title { get; set; } = null!;
	}
}
