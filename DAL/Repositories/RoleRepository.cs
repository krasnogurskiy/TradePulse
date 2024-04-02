using DAL.Repositories.Interfaces;
using DAL.Tools;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class RoleRepository : IRoleRepository
	{
		private readonly RoleManager<Role> _roleManager;
		public RoleRepository(RoleManager<Role> roleManager)
		{
			_roleManager = roleManager;
		}
		public Task<List<Role>> GetAllAllowedRolesAsync() =>
			_roleManager.Roles.Where(r => r.Name != "Admin").ToListAsync();

		public Task<Role?> GetByIdAsync(int id) =>
			_roleManager.FindByIdAsync(id.ToString());

		public Task<Role?> GetByTitleAsync(string title) =>
			_roleManager.FindByNameAsync(title);
	}
}
