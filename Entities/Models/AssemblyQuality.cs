using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class AssemblyQuality
    {
        public int ID { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }
        [ForeignKey("AssemblyFailureStateID")]
        public AssemblyFailureState? AssemblyFailureState { get; set; }
        public int? AssemblyFailureStateID { get; set; }
        public User? QualityOfficer { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}