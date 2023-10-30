using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ps.Models;

namespace ps.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NmCliente).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(255);
        }
    }
}
