using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(s => s.ID);
            builder.HasData(
                new Department { ID = 1, Name = "Yönetim" },
                new Department { ID = 2, Name = "Bilişim Teknolojileri" },
                new Department { ID = 3, Name = "Kalite" },
                new Department { ID = 4, Name = "Mühendis" },
                new Department { ID = 5, Name = "CNC Operator" },
                new Department { ID = 6, Name = "Tester" }
            );
        }
    }
}
