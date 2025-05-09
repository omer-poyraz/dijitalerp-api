namespace Entities.DTOs.AssemblyFailureStateDto
{
    public abstract record AssemblyFailureStateDtoForManipulation
    {
        public string? Inappropriateness { get; init; }
        public string? TechnicianID { get; init; }
        public string? Description { get; init; }
        public string? QualityOfficerDescription { get; init; }
        public DateTime? QualityDescriptionDate { get; set; }
        public string? PartCode { get; init; }
        public bool? Status { get; init; }
        public int? PendingQuantity { get; init; }
        public string? QualityOfficerID { get; init; }
        public DateTime? Date { get; set; }
        public int AssemblyManuelID { get; init; }
        public string? UserId { get; init; }
    }
}
