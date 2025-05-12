namespace Entities.DTOs.CMMFailureStateDto
{
    public record CMMFailureStateDtoForUpdate : CMMFailureStateDtoForManipulation
    {
        public int ID { get; init; }
        public bool? TrackChanges { get; init; } = false;
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
