namespace Entities.DTOs.CMMSuccessStateDto
{
    public record CMMSuccessStateDtoForUpdate : CMMSuccessStateDtoForManipulation
    {
        public int ID { get; init; }
        public bool? TrackChanges { get; init; } = false;
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
