using System;
using ExpectedObjects;
using GBCashback.Enums;
using GBCashback.Models;
using Xunit;

namespace GBCashback.Tests.Model
{
    public class RevendedorTest
    {
        [Fact]
        public void DeveCriarRevendedor()
        {
            var novoRevendedor = new
            {
                CPF = "09423321640",
                Nome = "Guilherme Lopes",
                Email = "guilherme@mail.com",
                Senha = "123456",
                Status = StatusRevendedor.EmValidacao
            };

            var revendedor = new Revendedor(novoRevendedor.CPF, novoRevendedor.Nome, novoRevendedor.Email, novoRevendedor.Senha);

            novoRevendedor.ToExpectedObject().ShouldMatch(revendedor);
        }

        [Fact]
        public void NaoDeveCriarRevendedorComCpfInvalido()
        {
            var novoRevendedor = new
            {
                CPF = "0000000",
                Nome = "Guilherme Lopes",
                Email = "guilherme@mail.com",
                Senha = "123456",
                Status = StatusRevendedor.EmValidacao
            };

            var erro =
                Assert.Throws<ArgumentException>(() => new Revendedor(novoRevendedor.CPF, novoRevendedor.Nome, novoRevendedor.Email, novoRevendedor.Senha))
                .Message;

                Assert.Equal("CPF inválido", erro);

        }
    }
}