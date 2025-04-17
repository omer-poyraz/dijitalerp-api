using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class AssemblyNote
    {
        public int ID { get; set; }
        public string? Note { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        [ForeignKey("AssemblyManuelID")]
        public AssemblyManuel? AssemblyManuel { get; set; }
        public int AssemblyManuelID { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
