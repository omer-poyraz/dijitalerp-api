using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class AssemblyFailureState
    {
        public int ID { get; set; }
        public string? Inappropriateness { get; set; }
        [ForeignKey("TechnicianID")]
        public User? Technician { get; set; }
        public string? TechnicianID { get; set; }
        public string? Description { get; set; }
        public string? PartCode { get; set; }
        public bool? Status { get; set; }
        public int? PendingQuantity { get; set; }
        [ForeignKey("QualityOfficerID")]
        public User? QualityOfficer { get; set; }
        public string? QualityOfficerID { get; set; }
        public ICollection<AssemblyQuality>? QualityOfficerDescriptions { get; set; }
        public DateTime? Date { get; set; }
        [ForeignKey("AssemblyManuelID")]
        public AssemblyManuel? AssemblyManuel { get; set; }
        public int AssemblyManuelID { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
