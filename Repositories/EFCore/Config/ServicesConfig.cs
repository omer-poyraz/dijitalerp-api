using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class ServicesConfig : IEntityTypeConfiguration<Services>
    {
        public void Configure(EntityTypeBuilder<Services> builder)
        {
            builder.HasKey(s => s.ID);

            builder.HasData(
                new Services { ID = 1, Name = "AssemblyFailureState", EndPoint = "/AssemblyFailureState", },
                new Services { ID = 2, Name = "AssemblyManuel", EndPoint = "/AssemblyManuel", },
                new Services { ID = 3, Name = "AssemblyNote", EndPoint = "/AssemblyNote", },
                new Services { ID = 4, Name = "AssemblySuccessState", EndPoint = "/AssemblySuccessState", },
                new Services { ID = 5, Name = "Department", EndPoint = "/Department", },
                new Services { ID = 6, Name = "Employee", EndPoint = "/Employee", },
                new Services { ID = 7, Name = "Log", EndPoint = "/Log", },
                new Services { ID = 8, Name = "User", EndPoint = "/User", },
                new Services { ID = 9, Name = "UserPermission", EndPoint = "/UserPermission", }
            );
        }
    }
}
