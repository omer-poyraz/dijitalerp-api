namespace Entities.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public ICollection<User>? Users { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
