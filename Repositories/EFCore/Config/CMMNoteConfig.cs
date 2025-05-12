using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CMMNoteConfig : IEntityTypeConfiguration<CMMNote>
    {
        public void Configure(EntityTypeBuilder<CMMNote> builder)
        {
            builder.HasKey(s => s.ID);
        }
    }
}
