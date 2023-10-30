using Microsoft.EntityFrameworkCore;
using ps.Data;
using ps.Models;
using ps.Repositories.Interfaces;

namespace ps.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CRUDDBContext _dbContext;
        public ClienteRepository(CRUDDBContext context)
        {
            _dbContext = context;
            
        }
        public async Task<List<Cliente>> ListarTodosUsuarios()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> BuscarPorId(int id)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task<Cliente> BuscarPorNome(string nome)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.NmCliente == nome);
        }


        public async Task<Cliente> Atualizar(Cliente cliente, int id)
        {
            Cliente byId = await BuscarPorId(id);
            if (byId == null)
            {
                throw new Exception($"Cliente com o id: {id} não encontrado.");
            }
            byId.NmCliente = cliente.NmCliente;
            byId.Cidade= cliente.Cidade;

            _dbContext.Clientes.Update(byId);
            await _dbContext.SaveChangesAsync();
            return byId;
        }


        public async Task<Cliente> Inserir(Cliente cliente)
        {
            _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }
        public async Task<bool> Apagar(int id)
        {
            Cliente byId = await BuscarPorId(id);
            if (byId == null)
            {
                throw new Exception($"Cliente com o id: {id} não encontrado.");
            }

            _dbContext.Clientes.Remove(byId);
            _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
