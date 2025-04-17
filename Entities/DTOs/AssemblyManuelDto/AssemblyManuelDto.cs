using Entities.Models;

namespace Entities.DTOs.AssemblyManuelDto
{
    public class AssemblyManuelDto
    {
        public int ID { get; init; }
        public ICollection<string>? Files { get; init; }
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
        public ICollection<AssemblyNote>? AssemblyNotes { get; init; }
        public ICollection<AssemblySuccessState>? BasariliDurumlar { get; init; }
        public ICollection<AssemblyFailureState>? BasarisizDurumlar { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
