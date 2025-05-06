namespace Entities.DTOs.TechnicalDrawingQualityDto
{
    public record TechnicalDrawingQualityDtoForInsertion : TechnicalDrawingQualityDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
