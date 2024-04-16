using BLL.DTOs;
using DAL.Tools;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllAsync();
    }
}