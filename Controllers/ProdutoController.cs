using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ps.Models;
using ps.Repositories;
using ps.Repositories.Interfaces;

namespace ps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> BuscarPorId(int id)
        {
            Produto produto = await _produtoRepository.BuscarPorId(id);
            return Ok(produto);
        }   
        
        [HttpGet("{DscProduto}")]
        public async Task<ActionResult<Produto>> BuscarPorDescricao(string descricao)
        {
            Produto produto = await _produtoRepository.BuscarPorDescricao(descricao);
            return Ok(produto);
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Listar()
        {
            List<Produto> vendas = await _produtoRepository.Listar();
            return Ok(vendas);
        }
        [HttpPost]
        public async Task<ActionResult<Produto>> Cadastrar([FromBody] Produto produto)
        {
            Produto produtoB = await _produtoRepository.Inserir(produto);
            return Ok(produtoB);
        }

        
        [HttpPut]
        public async Task<ActionResult<Produto>> Atualizar([FromBody] Produto produto, int id)
        {
            produto.Id = id;
            Produto produtoAtualizado = await _produtoRepository.Atualizar(produto, id);
            return Ok(produtoAtualizado);
        }      
        [HttpPut]
        public async Task<ActionResult<Produto>> Deletar(int id)
        {
            bool apagado= await _produtoRepository.Apagar(id);
            return Ok(apagado);
        }
    }
}
