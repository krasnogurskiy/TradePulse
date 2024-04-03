using BLL.DTOs;
using BLL.Errors;
using BLL.Features;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.Tools;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResult<User>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null) return new NotFoundError("Користувача не знайдено");

            bool isPasswordCorrect = await _userRepository.ComparePasswordsAsync(user, loginDto.Password);
            if (!isPasswordCorrect) return new ModelError("Неправильний пароль");

            return user;
        }
    }
}
