using System;
using System.ComponentModel.DataAnnotations;
using GBCashback.Enums;
using GBCashback.Models.Base;
using GBCashback.Util;
using Newtonsoft.Json;

namespace GBCashback.Models
{
    public class Revendedor : IEntity
    {
        public Revendedor()
        {

        }

        public Revendedor(string cpf, string nome, string email, string senha)
        {
            if (!Geral.ValidarCpf(cpf))
                throw new ArgumentException(Mensagens.CpfInvalido);

            this.CPF = cpf;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
        }

        public long Id { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        [MinLength(6)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MinLength(6)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [JsonIgnore]
        public StatusRevendedor Status { get; set; } = StatusRevendedor.EmValidacao;
    }
}