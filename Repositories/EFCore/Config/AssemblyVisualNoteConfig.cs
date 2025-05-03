using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Repositories.EFCore.Config
{
    public class AssemblyVisualNoteConfig : IEntityTypeConfiguration<AssemblyVisualNote>
    {
        public void Configure(EntityTypeBuilder<AssemblyVisualNote> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(b => b.Files).HasConversion(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<ICollection<string>>(v));
        }
    }
}
