using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Repositories.EFCore.Config
{
    public class TechnicalDrawingConfig : IEntityTypeConfiguration<TechnicalDrawing>
    {
        public void Configure(EntityTypeBuilder<TechnicalDrawing> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(b => b.Files).HasConversion(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<ICollection<string>>(v));
        }
    }
}
