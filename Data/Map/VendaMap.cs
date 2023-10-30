using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ps.Models;

namespace ps.Data.Map
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdCliente).IsRequired();
            builder.Property(x => x.IdProduto).IsRequired();
            builder.Property(x => x.QtdVenda).IsRequired();
            builder.Property(x => x.VlrUnitarioVenda).IsRequired();
            builder.Property(x => x.DthVenda).IsRequired().HasMaxLength(255);
        }
    }
}
