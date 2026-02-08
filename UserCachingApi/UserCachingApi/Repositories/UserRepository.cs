using UserCachingApi.Data;
using UserCachingApi.Models;
using Dapper;

namespace UserCachingApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnectionFactory _factory;

        public UserRepository(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using var conn = _factory.CreateConnection();
            return await conn.QueryAsync<User>("SELECT * FROM Users");
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            using var conn = _factory.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<User>(
                "SELECT * FROM Users WHERE Id=@Id",
                new { Id = id });
        }

        public async Task<bool> ExistsAsync(int id)
        {
            using var conn = _factory.CreateConnection();

            const string sql = "SELECT 1 FROM dbo.Users WHERE Id = @Id";

            var result = await conn.QueryFirstOrDefaultAsync<int?>(sql, new { Id = id });

            return result.HasValue;
        }

        public async Task InsertAsync(User user)
        {
            using var conn = _factory.CreateConnection();
            await conn.ExecuteAsync(
                @"INSERT INTO Users(Id,Name,Username,Email)
              VALUES(@Id,@Name,@Username,@Email)", user);
        }

        public async Task UpdateAsync(User user)
        {
            using var conn = _factory.CreateConnection();
            await conn.ExecuteAsync(
                @"UPDATE Users
              SET Name=@Name,
                  Username=@Username,
                  Email=@Email
              WHERE Id=@Id", user);
        }
    }
}
