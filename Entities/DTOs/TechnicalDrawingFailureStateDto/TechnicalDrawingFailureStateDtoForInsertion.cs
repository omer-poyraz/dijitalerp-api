namespace Entities.DTOs.TechnicalDrawingFailureStateDto
{
    public record TechnicalDrawingFailureStateDtoForInsertion : TechnicalDrawingFailureStateDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
