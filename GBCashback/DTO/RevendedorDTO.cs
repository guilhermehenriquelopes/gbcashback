using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GBCashback.DTO
{
    public class RevendedorDTO
    {        
        [Required]
        public string CPF { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}