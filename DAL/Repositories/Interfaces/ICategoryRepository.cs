using DAL.Tools;


namespace DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(int id);
    }
}
