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
                new Services { ID = 4, Name = "AssemblyQuality", EndPoint = "/AssemblyQuality", },
                new Services { ID = 5, Name = "AssemblySuccessState", EndPoint = "/AssemblySuccessState", },
                new Services { ID = 6, Name = "AssemblyVisualNote", EndPoint = "/AssemblyVisualNote", },
                new Services { ID = 7, Name = "Department", EndPoint = "/Department", },
                new Services { ID = 8, Name = "Employee", EndPoint = "/Employee", },
                new Services { ID = 9, Name = "Log", EndPoint = "/Log", },
                new Services { ID = 10, Name = "Product", EndPoint = "/Product", },
                new Services { ID = 11, Name = "Services", EndPoint = "/Services", },
                new Services { ID = 12, Name = "TechnicalDrawing", EndPoint = "/TechnicalDrawing", },
                new Services { ID = 13, Name = "TechnicalDrawingFailureState", EndPoint = "/TechnicalDrawingFailureState", },
                new Services { ID = 14, Name = "TechnicalDrawingNote", EndPoint = "/TechnicalDrawingNote", },
                new Services { ID = 15, Name = "TechnicalDrawingQuality", EndPoint = "/TechnicalDrawingQuality", },
                new Services { ID = 16, Name = "TechnicalDrawingSuccessState", EndPoint = "/TechnicalDrawingSuccessState", },
                new Services { ID = 17, Name = "TechnicalDrawingVisualNote", EndPoint = "/TechnicalDrawingVisualNote", },
                new Services { ID = 18, Name = "User", EndPoint = "/User", },
                new Services { ID = 19, Name = "UserPermission", EndPoint = "/UserPermission", }
            );
        }
    }
}
