using DAL.Repositories.Interfaces;
using DAL.Tools;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public Task<List<User>> GetAllAsync() =>
            _userManager.Users.ToListAsync();

        public Task<User?> GetByIdAsync(int id) =>
            _userManager.FindByIdAsync(id.ToString());

        public Task<User?> GetByEmailAsync(string email) =>
            _userManager.FindByEmailAsync(email);

        public Task<IdentityResult> CreateUserAsync(User user, string password) =>
         _userManager.CreateAsync(user, password);

        public Task<bool> ComparePasswordsAsync(User user, string password) =>
            _userManager.CheckPasswordAsync(user, password);

        public Task AddToRoleAsync(User user, string role) =>
            _userManager.AddToRoleAsync(user, role);

        public Task<bool> IsInRoleAsync(User user, string role) =>
            _userManager.IsInRoleAsync(user, role);

        public Task UpdateSecurityStampAsync(User user) =>
            _userManager.UpdateSecurityStampAsync(user);
    }
}
