namespace Entities.DTOs.TechnicalDrawingFailureStateDto
{
    public abstract record TechnicalDrawingFailureStateDtoForManipulation
    {
        public ICollection<string>? Files { get; set; }
        public string? Inappropriateness { get; init; }
        public string? ProjectName { get; init; }
        public string? Stand { get; init; }
        public string? PartCode { get; init; }
        public string? Description { get; init; }
        public int? ProductionQuantity { get; init; }
        public string? QuantityDescription { get; init; }
        public string? Approval { get; init; }
        public bool? Status { get; init; }
        public DateTime? Date { get; set; }
        public int? OperatorID { get; init; }
        public int? TechnicalDrawingID { get; init; }
        public string? UserId { get; init; }
    }
}
