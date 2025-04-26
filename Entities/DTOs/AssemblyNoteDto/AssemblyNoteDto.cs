using Entities.Models;

namespace Entities.DTOs.AssemblyNoteDto
{
    public class AssemblyNoteDto
    {
        public int ID { get; init; }
        public string? Note { get; init; }
        public string? PartCode { get; init; }
        public string? Description { get; init; }
        public bool? Status { get; init; }
        public AssemblyManuel? AssemblyManuel { get; init; }
        public int AssemblyManuelID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
