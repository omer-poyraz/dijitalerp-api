using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.CMMModuleDto
{
    public record CMMModuleDtoForUpdate : CMMModuleDtoForManipulation
    {
        public int ID { get; init; }
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public bool? TrackChanges { get; init; } = false;
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
