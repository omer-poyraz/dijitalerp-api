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
                new Services { ID = 7, Name = "CMM", EndPoint = "/CMM", },
                new Services { ID = 8, Name = "CMMModule", EndPoint = "/CMMModule", },
                new Services { ID = 9, Name = "CMMFailureState", EndPoint = "/CMMFailureState", },
                new Services { ID = 10, Name = "CMMSuccessState", EndPoint = "/CMMSuccessState", },
                new Services { ID = 11, Name = "CMMNote", EndPoint = "/CMMNote", },
                new Services { ID = 12, Name = "Department", EndPoint = "/Department", },
                new Services { ID = 13, Name = "Employee", EndPoint = "/Employee", },
                new Services { ID = 14, Name = "Log", EndPoint = "/Log", },
                new Services { ID = 15, Name = "Product", EndPoint = "/Product", },
                new Services { ID = 16, Name = "Services", EndPoint = "/Services", },
                new Services { ID = 17, Name = "TechnicalDrawing", EndPoint = "/TechnicalDrawing", },
                new Services { ID = 18, Name = "TechnicalDrawingFailureState", EndPoint = "/TechnicalDrawingFailureState", },
                new Services { ID = 19, Name = "TechnicalDrawingNote", EndPoint = "/TechnicalDrawingNote", },
                new Services { ID = 20, Name = "TechnicalDrawingQuality", EndPoint = "/TechnicalDrawingQuality", },
                new Services { ID = 21, Name = "TechnicalDrawingSuccessState", EndPoint = "/TechnicalDrawingSuccessState", },
                new Services { ID = 22, Name = "TechnicalDrawingVisualNote", EndPoint = "/TechnicalDrawingVisualNote", },
                new Services { ID = 23, Name = "User", EndPoint = "/User", },
                new Services { ID = 24, Name = "UserPermission", EndPoint = "/UserPermission", }
            );
        }
    }
}
