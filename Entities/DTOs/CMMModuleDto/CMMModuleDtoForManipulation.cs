namespace Entities.DTOs.CMMModuleDto
{
    public abstract record CMMModuleDtoForManipulation
    {
        public ICollection<string>? Files { get; set; }
        public string? CMM { get; init; }
        public string? UserId { get; init; }
    }
}
