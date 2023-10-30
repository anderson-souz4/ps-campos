using Microsoft.EntityFrameworkCore;
using ps.Data;
using ps.Models;
using ps.Repositories.Interfaces;

namespace ps.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly CRUDDBContext _dbContext;
        public VendaRepository(CRUDDBContext context)
        {
            _dbContext = context;
            
        }
        public async Task<List<Venda>> ListarVendas()
        {
            return await _dbContext.Vendas.ToListAsync();
        }

        public async Task<Venda> BuscarPorId(int id)
        {
            return await _dbContext.Vendas.FirstOrDefaultAsync(x => x.Id == id);

        }


        public async Task<Venda> Atualizar(Venda venda, int id)
        {
            Venda byId = await BuscarPorId(id);
            if (byId == null)
            {
                throw new Exception($"Venda com o id: {id} não encontrado.");
            }
            byId.IdCliente = venda.IdCliente;
            byId.IdProduto = venda.IdProduto;
            byId.QtdVenda = venda.QtdVenda;
            byId.VlrUnitarioVenda = venda.VlrUnitarioVenda;
            byId.DthVenda = venda.DthVenda;


            _dbContext.Vendas.Update(byId);
            await _dbContext.SaveChangesAsync();
            return byId;
        }


        public async Task<Venda> Inserir(Venda venda)
        {
            _dbContext.Vendas.AddAsync(venda);
            await _dbContext.SaveChangesAsync();
            return venda;
        }
        public async Task<bool> Apagar(int id)
        {
            Venda byId = await BuscarPorId(id);
            if (byId == null)
            {
                throw new Exception($"Venda com o id: {id} não encontrado.");
            }

            _dbContext.Vendas.Remove(byId);
            _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
