using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.AssemblyVisualNoteDto
{
    public record AssemblyVisualNoteDtoForInsertion : AssemblyVisualNoteDtoForManipulation
    {
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
