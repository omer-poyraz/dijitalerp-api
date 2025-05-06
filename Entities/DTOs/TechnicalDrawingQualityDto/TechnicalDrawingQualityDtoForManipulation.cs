namespace Entities.DTOs.TechnicalDrawingQualityDto
{
    public abstract record TechnicalDrawingQualityDtoForManipulation
    {
        public string? Description { get; init; }
        public string? Note { get; init; }
        public int? TechnicalDrawingFailureStateID { get; init; }
        public string? UserId { get; init; }
    }
}
