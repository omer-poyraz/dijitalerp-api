using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class AssemblyFailureStateConfig : IEntityTypeConfiguration<AssemblyFailureState>
    {
        public void Configure(EntityTypeBuilder<AssemblyFailureState> builder)
        {
            builder.HasKey(s => s.ID);
        }
    }
}
