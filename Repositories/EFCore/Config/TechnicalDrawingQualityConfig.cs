using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class TechnicalDrawingQualityConfig : IEntityTypeConfiguration<TechnicalDrawingQuality>
    {
        public void Configure(EntityTypeBuilder<TechnicalDrawingQuality> builder)
        {
            builder.HasKey(s => s.ID);
        }
    }
}
