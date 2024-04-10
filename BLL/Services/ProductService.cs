using BLL.DTOs;
using BLL.Errors;
using BLL.Features;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.Tools;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        //public async Task AddProductAsync(ProductDto productDto)
        //{
        //    await _productRepository.AddAsync(productDto);
        //    await _productRepository.SaveChangesAsync();
        //}

        public async Task<ServiceResult<ProductDto>> AddProductAsync(ProductDto productDto)
        {
            try
            {
                // Створити об'єкт Product з даних DTO
                var product = new Product
                {
                    Title = productDto.Title,
                    Price = productDto.Price,
                    ItemsAvailable = productDto.ItemsAvailable
                    // Додаткові поля, якщо такі є
                };

                // Зберегти продукт за допомогою репозиторію
                _productRepository.Add(product);
                _productRepository.SaveChanges();

                // Повернути успішний результат разом з даними про збережений продукт
                return ServiceResult<ProductDto>.Success(productDto);
                //return productDto;
            }
            catch (Exception ex)
            {
                // Обробити помилку та повернути її у вигляді результату
                return ServiceResult<ProductDto>.Failure($"Failed to add product: {ex.Message}");
            }
        }
    }
}
