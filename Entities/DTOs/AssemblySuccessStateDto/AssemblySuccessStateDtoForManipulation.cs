namespace Entities.DTOs.AssemblySuccessStateDto
{
    public abstract record AssemblySuccessStateDtoForManipulation
    {
        public string? Description { get; init; }
        public string? Technician { get; init; }
        public string? PartCode { get; init; }
        public string? Status { get; init; }
        public string? Approval { get; init; }
        public int? PendingQuantity { get; init; }
        public string? QualityDescription { get; init; }
        public DateTime? Date { get; init; }
        public int? AssemblyManuelID { get; init; }
        public string? UserId { get; init; }
    }
}
