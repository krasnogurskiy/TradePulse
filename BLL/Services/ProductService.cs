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
                var product = new Product
                {
                    Title = productDto.Title,
                    Price = productDto.Price,
                    ItemsAvailable = productDto.ItemsAvailable
                };

                _productRepository.Add(product);
                 _productRepository.SaveChangesAsync();

                //return ServiceResult<ProductDto>.Success(productDto);
                return productDto;
            }
            catch (Exception ex)
            {
                return ServiceResult<ProductDto>.Failure(new ModelError($"Failed to add product: {ex.Message}"));

            }
        }
    }
}
