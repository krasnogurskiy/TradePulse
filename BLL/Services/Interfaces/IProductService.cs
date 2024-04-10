using BLL.DTOs;
using BLL.Features;
using DAL.Tools;

namespace BLL.Services.Interfaces
{
    public interface IProductService
    {
        //public Task AddProductAsync(ProductDto productDto);
        Task<ServiceResult<ProductDto>> AddProductAsync(ProductDto productDto);

    }
}