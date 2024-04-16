using BLL.DTOs;
using BLL.Errors;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using System;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ServiceResult<ProductDto>> AddProductAsync(ProductDto productDto)
        {
            try
            {
                var product = new Product
                {
                    CategoryId = productDto.CategoryId,
                    Title = productDto.Title,
                    Description = productDto.Description,
                    Model = productDto.Model,
                    Price = productDto.Price,
                    ItemsAvailable = productDto.ItemsAvailable,
                    CreatedAt = DateTime.Now, 
                    VendorId = productDto.VendorId 
                };

                _productRepository.Add(product);
                _productRepository.SaveChangesAsync();
                //await _productRepository.SaveChangesAsync();

    

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
