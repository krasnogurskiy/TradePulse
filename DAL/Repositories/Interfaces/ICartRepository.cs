namespace DAL.Repositories.Interfaces
{
    public interface ICartRepository
    {
        public Task GetUsersCartAsync(int userId);

    }
}
