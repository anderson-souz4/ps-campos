using ps.Models;

namespace ps.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ListarTodosUsuarios();
        Task<Cliente> BuscarPorNome(string nome);
        Task<Cliente> Inserir(Cliente cliente);
        Task<Cliente> Atualizar (Cliente cliente, int id);
        Task<bool> Apagar(int id);
        Task<Cliente> BuscarPorId(int id);
    }
}
