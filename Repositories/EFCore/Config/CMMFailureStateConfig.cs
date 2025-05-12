using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CMMFailureStateConfig : IEntityTypeConfiguration<CMMFailureState>
    {
        public void Configure(EntityTypeBuilder<CMMFailureState> builder)
        {
            builder.HasKey(s => s.ID);
        }
    }
}
