namespace Entities.DTOs.CMMSuccessStateDto
{
    public abstract record CMMSuccessStateDtoForManipulation
    {
        public string? Description { get; init; }
        public string? TechnicianID { get; init; }
        public string? PartCode { get; init; }
        public bool? Status { get; init; }
        public string? Approval { get; init; }
        public int? PendingQuantity { get; init; }
        public string? QualityDescription { get; init; }
        public DateTime? Date { get; set; }
        public int? CMMID { get; init; }
        public string? UserId { get; init; }
    }
}
