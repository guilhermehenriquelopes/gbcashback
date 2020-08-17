using System.ComponentModel.DataAnnotations;
using System;
using GBCashback.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBCashback.Models
{
    public class Compra
    {
        public long Id { get; private set; }

        [Required]
        public Revendedor revendedor { get; set; }

        [Required]
        public Regra regra { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        public StatusCompra Status { get; set; } = StatusCompra.EmValidacao;
    }
}