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
        public string Codigo { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public Regra Regra { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required]
        [Range(0, 100)]
        [Column(TypeName = "decimal(3,2)")]
        public decimal CashbackPorcentagem { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CashbackValor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        public EnumStatus Status { get; set; } = EnumStatus.EmValidacao;
    }
}