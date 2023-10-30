using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ps.Models;
using ps.Repositories.Interfaces;

namespace ps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> BuscarTodosUsuarios()
        {
            List<Cliente> clientes = await _clienteRepository.ListarTodosUsuarios();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> BuscarPorId(int id)
        {
            Cliente cliente = await _clienteRepository.BuscarPorId(id);
            return Ok(cliente);
        }     
        [HttpGet("{nome}")]
        public async Task<ActionResult<Cliente>> BuscarPorNome(String nome)
        {
            Cliente cliente = await _clienteRepository.BuscarPorNome(nome);
            return Ok(cliente);
        }
        [HttpPost]
        public async Task<ActionResult<Cliente>> Cadastrar([FromBody] Cliente cliente)
        {
            Cliente clienteCriado = await _clienteRepository.Inserir(cliente);
            return Ok(clienteCriado);
        }     
        
        [HttpPut]
        public async Task<ActionResult<Cliente>> Atualizar([FromBody] Cliente cliente, int id)
        {
            cliente.Id = id;
            Cliente clienteAtualizado = await _clienteRepository.Atualizar(cliente, id);
            return Ok(clienteAtualizado);
        }      
        [HttpPut]
        public async Task<ActionResult<Cliente>> Deletar(int id)
        {
            bool apagado= await _clienteRepository.Apagar(id);
            return Ok(apagado);
        }
    }
}
