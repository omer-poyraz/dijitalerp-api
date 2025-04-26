using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class TechnicalDrawingFailureStateConfig : IEntityTypeConfiguration<TechnicalDrawingFailureState>
    {
        public void Configure(EntityTypeBuilder<TechnicalDrawingFailureState> builder)
        {
            builder.HasKey(s => s.ID);
        }
    }
}
