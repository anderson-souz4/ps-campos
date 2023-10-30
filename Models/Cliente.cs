using System.ComponentModel.DataAnnotations;

namespace ps.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        public string? NmCliente { get; set; }
        [Required(ErrorMessage = "Informe a cidade")]
        public string? Cidade {  get; set; }
    }
}
