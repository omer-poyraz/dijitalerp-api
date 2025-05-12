namespace Entities.DTOs.CMMFailureStateDto
{
    public abstract record CMMFailureStateDtoForManipulation
    {
        public string? Inappropriateness { get; init; }
        public string? TechnicianID { get; init; }
        public string? Description { get; init; }
        public string? QualityOfficerDescription { get; init; }
        public DateTime? QualityDescriptionDate { get; set; }
        public string? PartCode { get; init; }
        public bool? Status { get; init; }
        public int? PendingQuantity { get; init; }
        public int? Total { get; init; }
        public DateTime? Date { get; set; }
        public int CMMID { get; init; }
        public string? UserId { get; init; }
    }
}
