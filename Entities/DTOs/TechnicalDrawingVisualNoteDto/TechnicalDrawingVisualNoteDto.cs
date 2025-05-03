using Entities.Models;

namespace Entities.DTOs.TechnicalDrawingVisualNoteDto
{
    public class TechnicalDrawingVisualNoteDto
    {
        public int ID { get; init; }
        public ICollection<string>? Files { get; init; }
        public string? Note { get; init; }
        public string? Description { get; init; }
        public bool? Status { get; init; }
        public TechnicalDrawing? TechnicalDrawing { get; init; }
        public int TechnicalDrawingID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
