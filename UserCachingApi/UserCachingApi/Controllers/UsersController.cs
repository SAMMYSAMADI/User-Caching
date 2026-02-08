using Microsoft.AspNetCore.Mvc;
using UserCachingApi.DTOs;
using UserCachingApi.Models;
using UserCachingApi.Repositories;
using UserCachingApi.Services;


namespace UserCachingApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IExternalUserService _externalService;

        public UsersController(
            IUserRepository repository,
            IExternalUserService externalService)
        {
            _repository = repository;
            _externalService = externalService;
        }

        // GET ALL (CACHE)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repository.GetAllAsync();
            if (users.Any()) return Ok(users);

            var externalUsers = await _externalService.GetUsersAsync();
            foreach (var u in externalUsers)
                await _repository.InsertAsync(u);

            return Ok(externalUsers);
        }

        // GET BY ID (CACHE)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user != null) return Ok(user);

            var externalUser = await _externalService.GetUserAsync(id);

            if (externalUser == null) return NotFound();

            await _repository.InsertAsync(externalUser);

            return Ok(externalUser);
        }

        // INSERT
        [HttpPost]
        public async Task<IActionResult> Insert(User user)
        {
            if (user == null)
                return BadRequest("User data is required");

            // If client sends an ID, block duplicates
            if (user.Id > 0)
            {
                var exists = await _repository.ExistsAsync(user.Id);
                if (exists)
                    return Conflict($"User with ID {user.Id} already exists");
            }

            await _repository.InsertAsync(user);
            return Ok(user);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserDto dto)
        {
            if (dto == null)
                return BadRequest("User data is required");

            var user = await _repository.GetByIdAsync(id);
            if (user == null)
                return NotFound($"User with ID {id} not found");

            user.Name = dto.Name;
            user.Username = dto.Username;
            user.Email = dto.Email;

            await _repository.UpdateAsync(user);
            return Ok("User updated successfully");
        }

    }
}
