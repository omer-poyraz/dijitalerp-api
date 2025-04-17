namespace Entities.DTOs.ProductDto
{
    public abstract record ProductDtoForManipulation
    {
        public ICollection<string>? Files { get; set; }
        public string? Name { get; init; }
        public string? Code { get; init; }
        public int? Stock { get; init; }
        public decimal? Price { get; init; }
        public string? UserId { get; init; }
    }
}
