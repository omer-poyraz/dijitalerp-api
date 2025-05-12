namespace Entities.DTOs.CMMFailureStateDto
{
    public record CMMFailureStateDtoForInsertion : CMMFailureStateDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
