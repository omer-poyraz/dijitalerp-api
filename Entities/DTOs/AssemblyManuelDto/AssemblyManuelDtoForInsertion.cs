using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.AssemblyManuelDto
{
    public record AssemblyManuelDtoForInsertion : AssemblyManuelDtoForManipulation
    {
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
