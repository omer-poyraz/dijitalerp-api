namespace Entities.DTOs.TechnicalDrawingNoteDto
{
    public abstract record TechnicalDrawingNoteDtoForManipulation
    {
        public string? Note { get; init; }
        public string? PartCode { get; init; }
        public string? Description { get; init; }
        public bool? Status { get; init; }
        public int TechnicalDrawingID { get; init; }
        public string? UserId { get; init; }
    }
}
