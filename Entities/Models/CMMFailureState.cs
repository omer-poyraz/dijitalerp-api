using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class CMMFailureState
    {
        public int ID { get; set; }
        public string? Inappropriateness { get; set; }
        [ForeignKey("TechnicianID")]
        public User? Technician { get; set; }
        public string? TechnicianID { get; set; }
        public string? Description { get; set; }
        public string? QualityOfficerDescription { get; set; }
        public DateTime? QualityDescriptionDate { get; set; }
        public string? PartCode { get; set; }
        public bool? Status { get; set; }
        public int? PendingQuantity { get; set; }
        public int? Total { get; set; }
        [ForeignKey("QualityOfficerID")]
        public User? QualityOfficer { get; set; }
        public string? QualityOfficerID { get; set; }
        public DateTime? Date { get; set; }
        [ForeignKey("CMMID")]
        public CMM? CMM { get; set; }
        public int CMMID { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
