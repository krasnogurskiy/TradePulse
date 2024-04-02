using DAL.Tools;

namespace DAL.Repositories.Interfaces
{
	public interface IUserRepository
	{
		public Task<List<User>> GetAllAsync();
		public Task<User?> GetByIdAsync(int id);
		public Task CreateUserAsync(User user);
	}
}
