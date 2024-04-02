using DAL.Tools;

namespace DAL.Repositories.Interfaces
{
	public interface IRoleRepository
	{
		public Task<List<Role>> GetAllAllowedRolesAsync();
		public Task<Role?> GetByIdAsync(int id);
		public Task<Role?> GetByTitleAsync(string title);
	}
}
