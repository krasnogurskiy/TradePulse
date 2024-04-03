using DAL.Tools;

namespace DAL.Repositories.Interfaces
{
	public interface IUserRepository
	{
		public Task<List<User>> GetAllAsync();
		public Task<User?> GetByIdAsync(int id);
		public Task<User?> GetByEmailAsync(string email);
		public Task CreateUserAsync(User user);
		public Task<bool> ComparePasswordsAsync(User user, string password);
		public Task AddToRoleAsync(User user, string role);
		public Task<bool> IsInRoleAsync(User user, string role);
		public Task UpdateSecurityStampAsync(User user);
    }
}
