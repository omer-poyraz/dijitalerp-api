using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.CMMDto
{
    public record CMMDtoForInsertion : CMMDtoForManipulation
    {
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public ICollection<IFormFile>? resultFile { get; set; } = new List<IFormFile>();
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
