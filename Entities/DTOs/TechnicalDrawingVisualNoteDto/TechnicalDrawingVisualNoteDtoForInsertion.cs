using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.TechnicalDrawingVisualNoteDto
{
    public record TechnicalDrawingVisualNoteDtoForInsertion : TechnicalDrawingVisualNoteDtoForManipulation
    {
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
