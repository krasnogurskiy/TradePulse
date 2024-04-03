using BLL.DTOs;
using BLL.Errors;
using BLL.Features;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public AuthService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<ServiceResult<User>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null) return new NotFoundError("Користувача не знайдено");

            bool isPasswordCorrect = await _userRepository.ComparePasswordsAsync(user, loginDto.Password);
            if (!isPasswordCorrect) return new ModelError("Неправильний пароль");

            return user;
        }

        public async Task<ServiceResult<SignUpDto>> SignUpAsync(SignUpDto signUpDto)
        {
            bool isParsed = DateTime.TryParse(signUpDto.BirthDate,out DateTime birthDate);
            if (!isParsed) return new ModelError("Неправильний формат дати");

            var user = await _userRepository.GetByEmailAsync(signUpDto.Email);
            if (user != null) return new ModelError("Користувач з такою адресою вже зареєстрований");

            var role = await _roleRepository.GetByTitleAsync(signUpDto.Role);
            if (role == null) return new NotFoundError("Роль не існує");

            var newUser = new User()
            {
                FirstName = signUpDto.FirstName,
                LastName = signUpDto.LastName,
                BirthDate = birthDate.ToUniversalTime(),
                CreatedAt = DateTime.UtcNow,
                Email = signUpDto.Email,
                UserName = signUpDto.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userRepository.CreateUserAsync(newUser, signUpDto.Password);
            if (!result.Succeeded) return new ModelError(string.Join(", ", result.Errors).Replace("Fatal: ", string.Empty));
            await _userRepository.AddToRoleAsync(newUser, signUpDto.Role);

            return signUpDto;
        }

    }
}
