namespace Entities.DTOs.AssemblyManuelDto
{
    public abstract record AssemblyManuelDtoForManipulation
    {
        public ICollection<string>? Files { get; set; }
        public string? ProjectName { get; set; }
        public string? PartCode { get; set; }
        public string? Responible { get; set; }
        public string? PersonInCharge { get; set; }
        public string? SerialNumber { get; set; }
        public int? ProductionQuantity { get; set; }
        public int? Time { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public DateTime? TechnicianDate { get; set; }
        public string? UserId { get; set; }
    }
}
