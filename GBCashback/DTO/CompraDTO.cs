using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBCashback.DTO
{
    public class CompraDTO
    {
        [Required]
        public string Codigo { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}