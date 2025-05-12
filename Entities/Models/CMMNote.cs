using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class CMMNote
    {
        public int ID { get; set; }
        public string? Note { get; set; }
        public string? PartCode { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        [ForeignKey("CMMID")]
        public CMM? CMM { get; set; }
        public int CMMID { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
