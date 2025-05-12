using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.CMMDto
{
    public record CMMDtoForAddResultFile
    {
        public int ID { get; init; }
        public ICollection<string>? ResultFiles { get; set; }
        public ICollection<IFormFile>? resultFile { get; set; } = new List<IFormFile>();
        public bool? TrackChanges { get; init; } = false;
        public string? UserId { get; set; }
    }
}
