namespace Entities.DTOs.TechnicalDrawingQualityDto
{
    public record TechnicalDrawingQualityDtoForUpdate : TechnicalDrawingQualityDtoForManipulation
    {
        public int ID { get; init; }
        public bool? TrackChanges { get; init; } = false;
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
