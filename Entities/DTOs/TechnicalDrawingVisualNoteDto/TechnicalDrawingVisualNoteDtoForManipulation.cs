namespace Entities.DTOs.TechnicalDrawingVisualNoteDto
{
    public abstract record TechnicalDrawingVisualNoteDtoForManipulation
    {
        public ICollection<string>? Files { get; set; }
        public string? Note { get; init; }
        public string? Description { get; init; }
        public bool? Status { get; init; }
        public int TechnicalDrawingID { get; init; }
        public string? UserId { get; init; }
    }
}
