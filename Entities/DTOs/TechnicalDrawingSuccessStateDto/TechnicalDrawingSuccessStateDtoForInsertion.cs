namespace Entities.DTOs.TechnicalDrawingSuccessStateDto
{
    public record TechnicalDrawingSuccessStateDtoForInsertion : TechnicalDrawingSuccessStateDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
