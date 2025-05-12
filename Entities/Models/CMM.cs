using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class CMM
    {
        public int ID { get; set; }
        public ICollection<string>? Files { get; set; }
        public ICollection<string>? ResultFiles { get; set; }
        public string? ProjectName { get; set; }
        public string? PartCode { get; set; }
        public string? Stand { get; set; }
        public int? Time { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? InstallResultDate { get; set; }
        public string? SolidModel { get; set; }
        public string? Description { get; set; }
        [ForeignKey("MeasuringPersonID")]
        public User? MeasuringPerson { get; set; }
        public string? MeasuringPersonID { get; set; }
        [ForeignKey("CMMModuleID")]
        public CMMModule? CMMModule { get; set; }
        public int? CMMModuleID { get; set; }
        [ForeignKey("ResponibleID")]
        public User? Responible { get; set; }
        public string? ResponibleID { get; set; }
        [ForeignKey("PersonInChargeID")]
        public User? PersonInCharge { get; set; }
        public string? PersonInChargeID { get; set; }
        [ForeignKey("QualityOfficerID")]
        public User? QualityOfficer { get; set; }
        public string? QualityOfficerID { get; set; }
        public ICollection<CMMNote>? CMMNotes { get; set; }
        public ICollection<CMMSuccessState>? BasariliDurumlar { get; set; }
        public ICollection<CMMFailureState>? BasarisizDurumlar { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
