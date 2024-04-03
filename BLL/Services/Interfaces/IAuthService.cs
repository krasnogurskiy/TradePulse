using BLL.DTOs;
using BLL.Features;
using DAL.Tools;

namespace BLL.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<ServiceResult<User>> LoginAsync(LoginDto loginDto);
        public Task<ServiceResult<SignUpDto>> SignUpAsync(SignUpDto signUpDto);
    }
}
