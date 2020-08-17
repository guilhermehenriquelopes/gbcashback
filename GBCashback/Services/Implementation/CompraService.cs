using System;
using System.Collections.Generic;
using GBCashback.Enums;
using GBCashback.Models;
using GBCashback.Repository.Interface;
using GBCashback.Services.Interface;
using GBCashback.Util;

namespace GBCashback.Services.Implementation
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _repository;
        private readonly IRevendedorRepository _revendedorRepository;
        private readonly IRegraRepository _regraRepository;

        public CompraService(ICompraRepository repository, IRevendedorRepository revendedorRepository, IRegraRepository regraRepository)
        {
            _repository = repository;
            _revendedorRepository = revendedorRepository;
            _regraRepository = regraRepository;
        }

        public Compra Ativar(string cpf, string codigo)
        {
            cpf = Geral.FormatarCpf(cpf);

            var compra = _repository.ConsultarPorCpfCodigo(cpf, codigo);

            if (compra == null)
                throw new ArgumentException(Mensagens.NenhumRegistroEncontrado);

            compra.Status = EnumStatus.Aprovado;

            return _repository.Atualizar(compra);
        }

        public Compra Atualizar(Compra compra)
        {
            throw new NotImplementedException();
        }

        public Compra Cadastrar(Compra compra)
        {
            string cpf = Geral.FormatarCpf(compra.CPF);
            var revendedor = _revendedorRepository.ConsultarPorCpf(cpf);

            if (revendedor == null)
                throw new ArgumentException(Mensagens.NenhumRevendedorEncontrado);

            if (revendedor.Status != EnumStatus.Aprovado)
                throw new ArgumentException(Mensagens.UsuarioInativo);

            var duplicidade = _repository.ConsultarPorCpfCodigo(cpf, compra.Codigo);

            if (duplicidade != null)
                throw new ArgumentException(Mensagens.CompraJaRegistrada);

            var regra = _regraRepository.Consultar(compra.Valor);

            if (regra == null)
                throw new ArgumentException(Mensagens.NenhumaRegraEncontrada);

            compra.Status = Geral.ObtemStatusParaCadastro(cpf);
            compra.CPF = cpf;
            compra.Regra = regra;
            compra.CashbackPorcentagem = regra.Porcentagem;
            compra.CashbackValor = (decimal)(regra.Porcentagem / 100 * compra.Valor);

            return _repository.Cadastrar(compra);
        }

        public Compra Consultar(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Compra> Consultar()
        {
            throw new NotImplementedException();
        }

        public Compra Consultar(string cpf, string codigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Compra> Consultar(string cpf)
        {
            throw new NotImplementedException();
        }

        public Compra Deletar(long id)
        {
            throw new NotImplementedException();
        }
    }
}