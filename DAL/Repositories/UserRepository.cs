using DAL.Data;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _context;

		public UserRepository(AppDbContext context)
		{
			_context = context;
		}

		public Task<List<User>> GetAllAsync() =>
			_context.Users.ToListAsync();

		public Task<User?> GetByIdAsync(int id) =>
			_context.Users.FirstOrDefaultAsync(x => x.Id == id);

		public async Task CreateUserAsync(User user)
		{
			await _context.AddAsync(user);
			await _context.SaveChangesAsync();
		}
	}
}
