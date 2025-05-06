using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.UserDto
{
    public record UserDtoForUpdate : UserDtoForManipulation
    {
        [Required]
        public string? UserId { get; init; }
        public IFormFile? file { get; set; }
        public DateTime UpdateAt { get; init; } = DateTime.UtcNow;
    }
}
