using System.ComponentModel.DataAnnotations;

namespace GBCashback.DTO
{
   public class UsuarioDTO
    {
        [Required]
        public string CPF { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}