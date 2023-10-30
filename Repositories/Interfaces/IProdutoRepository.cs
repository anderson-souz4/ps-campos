using ps.Models;

namespace ps.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> BuscarPorId(int id);
        Task<Produto> BuscarPorDescricao(string id);
        Task<List<Produto>> Listar();
        Task<Produto> Inserir(Produto produto);
        Task<Produto> Atualizar (Produto produto, int id);
        Task<bool> Apagar(int id);

    }
}
