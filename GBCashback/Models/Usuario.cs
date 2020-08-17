using System.ComponentModel.DataAnnotations;

namespace GBCashback.Models
{
   public class Usuario
    {
        [Required]
        public string CPF { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}