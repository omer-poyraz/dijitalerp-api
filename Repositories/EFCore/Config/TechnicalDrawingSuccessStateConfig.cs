using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class TechnicalDrawingSuccessStateConfig : IEntityTypeConfiguration<TechnicalDrawingSuccessState>
    {
        public void Configure(EntityTypeBuilder<TechnicalDrawingSuccessState> builder)
        {
            builder.HasKey(s => s.ID);
        }
    }
}
