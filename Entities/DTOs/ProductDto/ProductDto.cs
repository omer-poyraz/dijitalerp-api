using Entities.Models;

namespace Entities.DTOs.ProductDto
{
    public class ProductDto
    {
        public int ID { get; init; }
        public ICollection<string>? Files { get; init; }
        public string? Name { get; init; }
        public string? Code { get; init; }
        public int? Stock { get; init; }
        public decimal? Price { get; init; }
        public string? UserId { get; init; }
        public User? User { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
