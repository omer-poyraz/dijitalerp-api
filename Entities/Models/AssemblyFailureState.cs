using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class AssemblyFailureState
    {
        public int ID { get; set; }
        public string? Inappropriateness { get; set; }
        public string? Technician { get; set; }
        public string? PartCode { get; set; }
        public string? Status { get; set; }
        public int? PendingQuantity { get; set; }
        public string? QualityDescription { get; set; }
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
