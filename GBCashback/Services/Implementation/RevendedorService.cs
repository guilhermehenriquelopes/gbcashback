using System;
using System.Collections.Generic;
using GBCashback.Enums;
using GBCashback.Models;
using GBCashback.Repository.Interface;
using GBCashback.Services.Interface;
using GBCashback.Util;

namespace GBCashback.Services.Implementation
{
    public class RevendedorService : IRevendedorService
    {
        private readonly IRevendedorRepository _repository;

        public RevendedorService(IRevendedorRepository repository)
        {
            _repository = repository;
        }

        public Revendedor Ativar(long id)
        {
            var revendedor = _repository.Consultar(id);

            if (revendedor == null)
                throw new Exception(Mensagens.NenhumRegistroEncontrado);

            revendedor.Status = StatusRevendedor.Aprovado;

            return _repository.Atualizar(revendedor);
        }

        public Revendedor Inativar(long id)
        {
            var revendedor = _repository.Consultar(id);

            if (revendedor == null)
                throw new Exception(Mensagens.NenhumRegistroEncontrado);

            revendedor.Status = StatusRevendedor.Inativo;

            return _repository.Atualizar(revendedor);
        }

        public Revendedor Atualizar(Revendedor revendedor)
        {
            if (!Geral.ValidarCpf(revendedor.CPF))
                throw new Exception(Mensagens.CpfInvalido);

            revendedor.CPF = Geral.FormatarCpf(revendedor.CPF);

            var duplicidade = ConsultarPorCpf(revendedor.CPF);

            if (duplicidade != null && duplicidade.Id != revendedor.Id)
                throw new Exception(Mensagens.CpfJaCadastrado);

            return _repository.Atualizar(revendedor);
        }

        public Revendedor Cadastrar(Revendedor revendedor)
        {
            if (!Geral.ValidarCpf(revendedor.CPF))
                throw new Exception(Mensagens.CpfInvalido);

            string cpf = Geral.FormatarCpf(revendedor.CPF);

            if (ConsultarPorCpf(cpf) != null)
                throw new Exception(Mensagens.CpfJaCadastrado);

            revendedor.CPF = Geral.FormatarCpf(revendedor.CPF);
            revendedor.Status = obtemStatusParaCadastro(revendedor.CPF);

            return _repository.Cadastrar(revendedor);
        }

        public IEnumerable<Revendedor> Consultar()
        {
            var revendedores = _repository.Consultar();

            foreach (var revendedor in revendedores)
            {
                revendedor.Senha = string.Empty;
            }

            return _repository.Consultar();
        }

        public Revendedor Consultar(long id)
        {
            var revendedor = _repository.Consultar(id);

            if (revendedor != null)
                revendedor.Senha = string.Empty;

            return revendedor;
        }

        public Revendedor ConsultarPorCpf(string cpf)
        {
            var revendedor = _repository.ConsultarPorCpf(cpf);

            return revendedor;
        }

        public Revendedor Deletar(long id)
        {
            throw new NotImplementedException();
        }

        private StatusRevendedor obtemStatusParaCadastro(string cpf)
        {
            string cpfAprovado = "153.509.460-56";

            if (cpf == cpfAprovado)
            {
                return StatusRevendedor.Aprovado;
            }
            else
            {
                return StatusRevendedor.EmValidacao;
            }
        }
    }
}