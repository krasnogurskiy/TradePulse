using BLL.DTOs;
using BLL.Features;
using DAL.Tools;

namespace BLL.Services.Interfaces
{
    public interface IProductService
    {
        void AddProduct(Product product);
    }
}