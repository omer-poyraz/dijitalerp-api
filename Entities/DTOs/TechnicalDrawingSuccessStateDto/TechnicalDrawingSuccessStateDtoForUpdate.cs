namespace Entities.DTOs.TechnicalDrawingSuccessStateDto
{
    public record TechnicalDrawingSuccessStateDtoForUpdate : TechnicalDrawingSuccessStateDtoForManipulation
    {
        public int ID { get; init; }
        public bool? TrackChanges { get; init; } = false;
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
