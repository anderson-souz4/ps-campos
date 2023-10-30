using Microsoft.EntityFrameworkCore;
using ps.Data;
using ps.Models;
using ps.Repositories.Interfaces;

namespace ps.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CRUDDBContext _dbContext;
        public ProdutoRepository(CRUDDBContext context)
        {
            _dbContext = context;
            
        }
        public async Task<List<Produto>> Listar()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);

        }


        public async Task<Produto> Atualizar(Produto produto, int id)
        {
            Produto byId = await BuscarPorId(id);
            if (byId == null)
            {
                throw new Exception($"Produto com o id: {id} não encontrado.");
            }
            byId.Id = produto.Id;
            byId.DscProduto= produto.DscProduto;
            byId.VlrUnitario= produto.VlrUnitario;


            _dbContext.Produtos.Update(byId);
            await _dbContext.SaveChangesAsync();
            return byId;
        }


        public async Task<Produto> Inserir(Produto produto)
        {
            _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }
        public async Task<bool> Apagar(int id)
        {
            Produto byId = await BuscarPorId(id);
            if (byId == null)
            {
                throw new Exception($"Produto com o id: {id} não encontrado.");
            }

            _dbContext.Produtos.Remove(byId);
            _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Produto> BuscarPorDescricao(string descricao)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.DscProduto == descricao);
        }
    }
}
