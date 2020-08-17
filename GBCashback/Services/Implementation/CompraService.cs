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

        public CompraService(ICompraRepository repository)
        {
            _repository = repository;
        }

        public Compra Atualizar(Compra compra)
        {
            throw new NotImplementedException();
        }

        public Compra Cadastrar(Compra compra)
        {
            throw new NotImplementedException();
        }

        public Compra Consultar(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Compra> Consultar()
        {
            throw new NotImplementedException();
        }

        public Compra Deletar(long id)
        {
            throw new NotImplementedException();
        }
    }
}