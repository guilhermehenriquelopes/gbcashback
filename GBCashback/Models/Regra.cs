using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBCashback.Models
{
    public class Regra
    {
        public long Id { get; private set; }

        [Required]
        [Range(0, long.MaxValue)]
        [Column(TypeName = "numeric(18,2)")]
        public decimal ValorInicial { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorFinal { get; set; }

        [Required]
        [Range(0, 100)]         
        [Column(TypeName = "decimal(5,2)")]
        public decimal Porcentagem { get; set; }
    }
}