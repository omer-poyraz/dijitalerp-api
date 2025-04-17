namespace Entities.DTOs.AssemblyManuelDto
{
    public abstract record AssemblyManuelDtoForManipulation
    {
        public ICollection<string>? Files { get; set; }
        public string? ProjectName { get; init; }
        public string? PartCode { get; init; }
        public string? Responible { get; init; }
        public string? PersonInCharge { get; init; }
        public string? SerialNumber { get; init; }
        public int? ProductionQuantity { get; init; }
        public int? Time { get; init; }
        public DateTime? Tarih { get; init; }
        public string? Description { get; init; }
        public DateTime? TeknisyenTarih { get; init; }
        public string? UserId { get; init; }
    }
}
