using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.AssemblyManuelDto
{
    public record AssemblyManuelDtoForAddFile
    {
        public int ID { get; init; }
        public ICollection<string>? Files { get; set; }
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public bool? TrackChanges { get; init; } = false;
        public string? UserId { get; set; }
    }
}
