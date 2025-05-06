namespace Entities.DTOs.AssemblyManuelDto
{
    public abstract record AssemblyManuelDtoForManipulation
    {
        public ICollection<string>? Files { get; set; }
        public string? ProjectName { get; set; }
        public string? PartCode { get; set; }
        public string? ResponibleID { get; init; }
        public string? PersonInChargeID { get; init; }
        public string? SerialNumber { get; set; }
        public int? ProductionQuantity { get; set; }
        public string? QualityOfficerID { get; init; }
        public int? Time { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public DateTime? TechnicianDate { get; set; }
        public string? UserId { get; set; }
    }
}
