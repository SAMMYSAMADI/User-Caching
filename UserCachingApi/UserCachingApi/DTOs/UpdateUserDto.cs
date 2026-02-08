using System.ComponentModel.DataAnnotations;

namespace UserCachingApi.DTOs
{
    public class UpdateUserDto
    {
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Username { get; set; } = "";
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
    }
}
