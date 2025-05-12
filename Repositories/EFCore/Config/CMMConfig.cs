using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Repositories.EFCore.Config
{
    public class CMMConfig : IEntityTypeConfiguration<CMM>
    {
        public void Configure(EntityTypeBuilder<CMM> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(b => b.Files).HasConversion(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<ICollection<string>>(v));
            builder.Property(b => b.ResultFiles).HasConversion(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<ICollection<string>>(v));
        }
    }
}
