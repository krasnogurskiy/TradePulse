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
            var user = await _userRepository.GetByEmailAsync(signUpDto.Email);
            if (user != null) return new ModelError("Користувач з такою адресою вже зареєстрований");

            if (signUpDto.BirthDate.AddYears(18) > DateTime.Now) return new ModelError("Користувачеві повинно виповнитись 18 років");

            var role = await _roleRepository.GetByTitleAsync(signUpDto.Role);
            if (role == null) return new NotFoundError("Роль не існує");

            var newUser = new User()
            {
                FirstName = signUpDto.FirstName,
                LastName = signUpDto.LastName,
                BirthDate = signUpDto.BirthDate.ToUniversalTime(),
                CreatedAt = DateTime.UtcNow,
                Email = signUpDto.Email,
                UserName = signUpDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                Cart = new Cart()
            };
            var result = await _userRepository.CreateUserAsync(newUser, signUpDto.Password);
            if (!result.Succeeded) return new ModelError(string.Join(", ", result.Errors).Replace("Fatal: ", string.Empty));
            await _userRepository.AddToRoleAsync(newUser, signUpDto.Role);

            return signUpDto;
        }

        public async Task<ServiceResult<UpdateUserDto>> UpdateUserAsync(UpdateUserDto updateUserData)
        {
            var user = await _userRepository.GetByIdAsync(updateUserData.Id);
            if (user == null) return new NotFoundError("Користувача не знайдено");

            user.FirstName = updateUserData.FirstName;
            user.LastName = updateUserData.LastName;
            user.BirthDate = updateUserData.BirthDate.ToUniversalTime();

            await _userRepository.UpdateUserAsync(user);
            return updateUserData;
        }

        public async Task<ServiceResult<int>> DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return new NotFoundError("Користувача не знайдено");
            await _userRepository.DeleteUserAsync(user);

            return 0;
        }
    }
}
