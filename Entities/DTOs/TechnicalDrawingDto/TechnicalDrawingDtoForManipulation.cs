namespace Entities.DTOs.TechnicalDrawingDto
{
    public abstract record TechnicalDrawingDtoForManipulation
    {
        public ICollection<string>? Files { get; set; }
        public string? ProjectName { get; init; }
        public string? PartCode { get; init; }
        public string? Stand { get; init; }
        public string? QualityOfficerDescription { get; init; }
        public DateTime? QualityDescriptionDate { get; init; }
        public string? ResponibleID { get; init; }
        public string? PersonInChargeID { get; init; }
        public string? SerialNumber { get; init; }
        public int? ProductionQuantity { get; init; }
        public string? QualityOfficerID { get; init; }
        public int? Time { get; init; }
        public DateTime? Date { get; set; }
        public string? Description { get; init; }
        public DateTime? OperatorDate { get; set; }
        public string? UserId { get; init; }
    }
}
