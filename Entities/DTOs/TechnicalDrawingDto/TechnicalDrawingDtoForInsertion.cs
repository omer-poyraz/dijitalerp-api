using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.TechnicalDrawingDto
{
    public record TechnicalDrawingDtoForInsertion : TechnicalDrawingDtoForManipulation
    {
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
