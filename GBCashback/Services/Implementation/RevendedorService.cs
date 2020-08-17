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

        public Revendedor Ativar(string cpf)
        {
            cpf = Geral.FormatarCpf(cpf);

            if (!Geral.ValidarCpf(cpf))
                throw new ArgumentException(Mensagens.CpfInvalido);

            var revendedor = _repository.ConsultarPorCpf(cpf);

            if (revendedor == null)
                throw new Exception(Mensagens.NenhumRegistroEncontrado);

            revendedor.Status = EnumStatus.Aprovado;

            return _repository.Atualizar(revendedor);
        }

        public Revendedor Atualizar(Revendedor revendedor)
        {
            var entidade = _repository.Consultar(revendedor.Id);

            if (entidade == null)
                throw new ArgumentException(Mensagens.NenhumRegistroEncontrado);

            revendedor.CPF = Geral.FormatarCpf(revendedor.CPF);

            if (entidade.CPF != revendedor.CPF)
                throw new ArgumentException(Mensagens.CpfDiferente);

            if (!Geral.ValidarEmail(revendedor.Email))
                throw new ArgumentException(Mensagens.EmailInvalido);

            var porEmail = ConsultarPorEmail(revendedor.Email);

            if (porEmail != null && porEmail.Id != entidade.Id)
                throw new ArgumentException(Mensagens.EmailJaCadastrado);

            entidade.Nome = revendedor.Nome;
            entidade.Email = revendedor.Email;
            entidade.Senha = revendedor.Senha;
            entidade.Status = revendedor.Status;

            return _repository.Atualizar(entidade);
        }

        public Revendedor Cadastrar(Revendedor revendedor)
        {
            if (!Geral.ValidarCpf(revendedor.CPF))
                throw new ArgumentException(Mensagens.CpfInvalido);

            if (!Geral.ValidarEmail(revendedor.Email))
                throw new ArgumentException(Mensagens.EmailInvalido);

            string cpf = Geral.FormatarCpf(revendedor.CPF);

            if (ConsultarPorCpf(cpf) != null)
                throw new ArgumentException(Mensagens.CpfJaCadastrado);

            if (ConsultarPorEmail(revendedor.Email) != null)
                throw new ArgumentException(Mensagens.EmailJaCadastrado);

            revendedor.CPF = Geral.FormatarCpf(revendedor.CPF);
            revendedor.Status = Geral.ObtemStatusParaCadastro(revendedor.CPF);

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

        public Revendedor Deletar(long id)
        {
            var entidade = _repository.Consultar(id);

            if (entidade == null)
                throw new ArgumentException(Mensagens.NenhumRegistroEncontrado);

            return _repository.Deletar(id);
        }

        private Revendedor ConsultarPorCpf(string cpf)
        {
            var revendedor = _repository.ConsultarPorCpf(cpf);

            return revendedor;
        }

        private Revendedor ConsultarPorEmail(string email)
        {
            var revendedor = _repository.ConsultarPorEmail(email);

            return revendedor;
        }

        public Revendedor ConsultarPorCpfSenha(string cpf, string senha)
        {
            var revendedor = _repository.ConsultarPorCpfSenha(Geral.FormatarCpf(cpf), senha);

            if (revendedor != null && revendedor.Status != EnumStatus.Aprovado)
                throw new ArgumentException(Mensagens.UsuarioInativo);

            return revendedor;
        }
    }
}