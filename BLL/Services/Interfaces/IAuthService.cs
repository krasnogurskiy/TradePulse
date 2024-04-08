using BLL.DTOs;
using BLL.Errors;
using BLL.Features;
using DAL.Tools;

namespace BLL.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<ServiceResult<User>> LoginAsync(LoginDto loginDto);
        public Task<ServiceResult<SignUpDto>> SignUpAsync(SignUpDto signUpDto);
        public Task<ServiceResult<UpdateUserDto>> UpdateUserAsync(UpdateUserDto updateUserData);
        public Task<ServiceResult<int>> DeleteUserAsync(int id);
    }
}
