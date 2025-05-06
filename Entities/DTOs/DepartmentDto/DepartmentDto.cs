using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models;

namespace Entities.DTOs.DepartmentDto
{
    public class DepartmentDto
    {
        public int ID { get; init; }
        public string? Name { get; init; }
        public ICollection<User>? Users { get; set; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
