namespace Entities.DTOs.TechnicalDrawingFailureStateDto
{
    public record TechnicalDrawingFailureStateDtoForUpdate : TechnicalDrawingFailureStateDtoForManipulation
    {
        public int ID { get; init; }
        public bool? TrackChanges { get; init; } = false;
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
