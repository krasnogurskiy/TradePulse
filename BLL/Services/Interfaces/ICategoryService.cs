using BLL.DTOs;
using DAL.Tools;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllAsync();
    }
}
