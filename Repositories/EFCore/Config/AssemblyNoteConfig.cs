using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class AssemblyNoteConfig : IEntityTypeConfiguration<AssemblyNote>
    {
        public void Configure(EntityTypeBuilder<AssemblyNote> builder)
        {
            builder.HasKey(s => s.ID);
        }
    }
}
