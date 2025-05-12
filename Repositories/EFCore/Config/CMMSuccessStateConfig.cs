using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CMMSuccessStateConfig : IEntityTypeConfiguration<CMMSuccessState>
    {
        public void Configure(EntityTypeBuilder<CMMSuccessState> builder)
        {
            builder.HasKey(s => s.ID);
        }
    }
}
