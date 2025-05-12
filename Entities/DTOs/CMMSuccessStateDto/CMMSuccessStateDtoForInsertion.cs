namespace Entities.DTOs.CMMSuccessStateDto
{
    public record CMMSuccessStateDtoForInsertion : CMMSuccessStateDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
