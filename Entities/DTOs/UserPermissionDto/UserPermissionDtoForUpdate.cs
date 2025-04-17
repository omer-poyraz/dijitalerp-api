namespace Entities.DTOs.UserPermissionDto
{
    public record UserPermissionDtoForUpdate : UserPermissionDtoForManipulation
    {
        public int ID { get; init; }
        public bool? TrackChanges { get; init; } = false;
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
