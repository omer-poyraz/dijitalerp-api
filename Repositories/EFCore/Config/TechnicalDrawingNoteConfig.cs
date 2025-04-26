using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class TechnicalDrawingNoteConfig : IEntityTypeConfiguration<TechnicalDrawingNote>
    {
        public void Configure(EntityTypeBuilder<TechnicalDrawingNote> builder)
        {
            builder.HasKey(s => s.ID);
        }
    }
}
