namespace Entities.Models
{
    public class Product
    {
        public int ID { get; set; }
        public ICollection<string>? Files { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
