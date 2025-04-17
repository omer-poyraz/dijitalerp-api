using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class AssemblySuccessStateConfig : IEntityTypeConfiguration<AssemblySuccessState>
    {
        public void Configure(EntityTypeBuilder<AssemblySuccessState> builder)
        {
            builder.HasKey(s => s.ID);
        }
    }
}
