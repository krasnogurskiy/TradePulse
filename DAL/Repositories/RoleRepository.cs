using DAL.Data;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class RoleRepository : IRoleRepository
	{
		private readonly AppDbContext _context;
		public RoleRepository(AppDbContext context)
		{
			_context = context;
		}
		public Task<List<Role>> GetAllAllowedRolesAsync() =>
			_context.Roles.Where(r => r.Title != "Admin").ToListAsync();

		public Task<Role?> GetByIdAsync(int id) =>
			_context.Roles.FirstOrDefaultAsync(r => r.Id == id);

		public Task<Role?> GetByTitleAsync(string title) =>
			_context.Roles.FirstOrDefaultAsync(r => r.Title == "title");
	}
}
