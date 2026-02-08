using UserCachingApi.Models;

namespace UserCachingApi.Services
{
    public interface IExternalUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserAsync(int id);
    }
}
