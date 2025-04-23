using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class AssemblySuccessState
    {
        public int ID { get; set; }
        public string? Description { get; set; }
        [ForeignKey("TechnicianID")]
        public Employee? Technician { get; set; }
        public int? TechnicianID { get; set; }
        public string? PartCode { get; set; }
        public bool? Status { get; set; }
        public string? Approval { get; set; }
        public int? PendingQuantity { get; set; }
        public string? QualityDescription { get; set; }
        public DateTime? Date { get; set; }
        [ForeignKey("AssemblyManuelID")]
        public AssemblyManuel? AssemblyProject { get; set; }
        public int? AssemblyManuelID { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
