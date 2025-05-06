using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class AssemblyQualityConfig : IEntityTypeConfiguration<AssemblyQuality>
    {
        public void Configure(EntityTypeBuilder<AssemblyQuality> builder)
        {
            builder.HasKey(s => s.ID);
        }
    }
}
