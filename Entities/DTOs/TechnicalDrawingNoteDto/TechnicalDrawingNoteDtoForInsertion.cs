namespace Entities.DTOs.TechnicalDrawingNoteDto
{
    public record TechnicalDrawingNoteDtoForInsertion : TechnicalDrawingNoteDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
