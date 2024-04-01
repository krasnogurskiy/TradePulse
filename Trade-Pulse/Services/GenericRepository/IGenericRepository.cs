namespace Trade_Pulse.Services.GenericRepository
{
	public interface IGenericRepository<T>
	{
		public Task<List<T>> GetAll();
		public Task<T?> GetById(int id);
		public IQueryable<T> GetQueryable();
		public Task Create(T entity);
		public void Update(T entity);
		public void Delete(T entity);
		public void Save();
		public Task SaveAsync();
	}
}
