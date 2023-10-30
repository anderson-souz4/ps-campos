using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ps.Models;
using ps.Repositories;
using ps.Repositories.Interfaces;

namespace ps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaRepository _vendaRepository;
        public VendaController(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> BuscarPorId(int id)
        {
            Venda venda = await _vendaRepository.BuscarPorId(id);
            return Ok(venda);
        }

        [HttpGet]
        public async Task<ActionResult<List<Venda>>> ListarVendas()
        {
            List<Venda> vendas = await _vendaRepository.ListarVendas();
            return Ok(vendas);
        }
        [HttpPost]
        public async Task<ActionResult<Venda>> Cadastrar([FromBody] Venda venda)
        {
            Venda vendaEfetuada = await _vendaRepository.Inserir(venda);
            return Ok(vendaEfetuada);
        }

    
        
        [HttpPut]
        public async Task<ActionResult<Venda>> Atualizar([FromBody] Venda venda, int id)
        {
            venda.Id = id;
            Venda vendaAtualizada = await _vendaRepository.Atualizar(venda, id);
            return Ok(vendaAtualizada);
        }      
        [HttpPut]
        public async Task<ActionResult<Venda>> Deletar(int id)
        {
            bool apagado= await _vendaRepository.Apagar(id);
            return Ok(apagado);
        }
    }
}
