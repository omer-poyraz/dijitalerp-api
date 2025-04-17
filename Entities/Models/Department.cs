namespace Entities.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
