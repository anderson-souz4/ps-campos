using ps.Models;

namespace ps.Repositories.Interfaces
{
    public interface IVendaRepository
    {
        Task<Venda> BuscarPorId(int id);
        Task<List<Venda>> ListarVendas();
        Task<Venda> Inserir(Venda cliente);
        Task<Venda> Atualizar (Venda cliente, int id);
        Task<bool> Apagar(int id);

    }
}
