using UserCachingApi.Models;

namespace UserCachingApi.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task InsertAsync(User user);

    }
}
