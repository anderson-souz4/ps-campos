using Microsoft.EntityFrameworkCore;
using ps.Data.Map;
using ps.Models;

namespace ps.Data
{
    public class CRUDDBContext : DbContext
    {
        public CRUDDBContext(DbContextOptions<CRUDDBContext> options) : base(options){ }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Produto> Produtos{ get; set; }
        public DbSet<Cliente> Clientes{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            base.OnModelCreating(modelBuilder);
        }

    }


}
