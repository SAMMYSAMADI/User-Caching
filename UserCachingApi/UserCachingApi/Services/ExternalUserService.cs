using UserCachingApi.Models;

namespace UserCachingApi.Services
{
    public class ExternalUserService : IExternalUserService
    {
        private readonly HttpClient _client;

        public ExternalUserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _client.GetFromJsonAsync<List<User>>(
                "https://jsonplaceholder.typicode.com/users") ?? new();
        }

        public async Task<User?> GetUserAsync(int id)
        {
            return await _client.GetFromJsonAsync<User>(
                $"https://jsonplaceholder.typicode.com/users/{id}");
        }
    }
}
