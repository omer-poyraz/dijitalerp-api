using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.ProductDto
{
    public record ProductDtoForInsertion : ProductDtoForManipulation
    {
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
