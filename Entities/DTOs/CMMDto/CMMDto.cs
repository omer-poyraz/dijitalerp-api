using Entities.Models;

namespace Entities.DTOs.CMMDto
{
    public class CMMDto
    {
        public int ID { get; init; }
        public ICollection<string>? Files { get; init; }
        public ICollection<string>? ResultFiles { get; init; }
        public string? ProjectName { get; init; }
        public string? PartCode { get; init; }
        public string? Stand { get; init; }
        public int? Time { get; init; }
        public DateTime? Date { get; init; }
        public DateTime? InstallResultDate { get; init; }
        public string? SolidModel { get; init; }
        public string? Description { get; init; }
        public User? MeasuringPerson { get; init; }
        public string? MeasuringPersonID { get; init; }
        public CMMModule? CMMModule { get; init; }
        public int? CMMModuleID { get; init; }
        public User? Responible { get; init; }
        public string? ResponibleID { get; init; }
        public User? PersonInCharge { get; init; }
        public string? PersonInChargeID { get; init; }
        public User? QualityOfficer { get; init; }
        public string? QualityOfficerID { get; init; }
        public ICollection<CMMNote>? CMMNotes { get; init; }
        public ICollection<CMMSuccessState>? BasariliDurumlar { get; init; }
        public ICollection<CMMFailureState>? BasarisizDurumlar { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
