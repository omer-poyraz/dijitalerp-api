using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class CMMModule
    {
        public int ID { get; set; }
        public ICollection<string>? Files { get; set; }
        public string? CMM { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
