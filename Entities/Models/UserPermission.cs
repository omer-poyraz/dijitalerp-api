using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Entities.Models
{
    public class UserPermission
    {
        public int ID { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public string? ServiceName { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanDelete { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
