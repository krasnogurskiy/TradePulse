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
                    Description = productDto.Description,
                    Model = productDto.Model,
                    Price = productDto.Price,
                    ItemsAvailable = productDto.ItemsAvailable,
                    CreatedAt = DateTime.Now.ToUniversalTime(),
                };

                await _productRepository.Add(product, productDto.VendorId, productDto.CategoryId);
                return productDto;
            }
            catch (Exception ex)
            {
                return ServiceResult<ProductDto>.Failure(new ModelError($"Failed to add product: {ex.Message}"));
            }
        }
        public async Task<List<Product>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = _productRepository.GetByIdAsync(id).Result;
            return product;
        }

        public async Task<List<Product>> GetAllByCategoryAsync(int category_id)
        {
            var product = await _productRepository.GetAllByCategoryAsync(category_id);
            return product;
        }
    }
}