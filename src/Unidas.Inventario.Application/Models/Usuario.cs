using System.ComponentModel.DataAnnotations;

namespace Unidas.Inventario.Application.Models
{
    public class Usuario
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }

        public bool Ativo { get; set; }
    }
}
