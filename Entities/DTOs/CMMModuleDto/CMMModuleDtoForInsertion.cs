using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.CMMModuleDto
{
    public record CMMModuleDtoForInsertion : CMMModuleDtoForManipulation
    {
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
