using Microsoft.EntityFrameworkCore;
using Trade_Pulse.Data;

namespace Trade_Pulse.Services.GenericRepository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private DbSet<T> table;
		private readonly AppDbContext _context;
		public GenericRepository(AppDbContext ctx)
		{
			_context = ctx;
			table = _context.Set<T>();
		}
		public async Task Create(T entity)
		{
			await table.AddAsync(entity);
		}

		public void Delete(T entity)
		{
			table.Remove(entity);
		}

		public Task<List<T>> GetAll() =>
			table.ToListAsync();

		public async Task<T?> GetById(int id)
		{
			return await table.FindAsync(id);
		}

		public IQueryable<T> GetQueryable() =>
			table.AsQueryable<T>();

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			table.Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}
	}
}
