using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class AssemblyManuel
    {
        public int ID { get; set; }
        public ICollection<string>? Files { get; set; }
        public string? ProjectName { get; set; }
        public string? PartCode { get; set; }
        
        [ForeignKey("ResponibleID")]
        public User? Responible { get; set; }
        public string? ResponibleID { get; set; }
        [ForeignKey("PersonInChargeID")]
        public User? PersonInCharge { get; set; }
        public string? PersonInChargeID { get; set; }
        [ForeignKey("QualityOfficerID")]
        public User? QualityOfficer { get; set; }
        public string? QualityOfficerID { get; set; }

        public string? SerialNumber { get; set; }
        public int? ProductionQuantity { get; set; }
        public int? Time { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public DateTime? TechnicianDate { get; set; }
        public ICollection<AssemblyNote>? AssemblyNotes { get; set; }
        public ICollection<AssemblySuccessState>? BasariliDurumlar { get; set; }
        public ICollection<AssemblyFailureState>? BasarisizDurumlar { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
