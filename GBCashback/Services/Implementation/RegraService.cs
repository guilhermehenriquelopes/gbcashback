using System;
using System.Collections.Generic;
using GBCashback.Enums;
using GBCashback.Models;
using GBCashback.Repository.Interface;
using GBCashback.Services.Interface;
using GBCashback.Util;

namespace GBCashback.Services.Implementation
{
    public class RegraService : IRegraService
    {
        private readonly IRegraRepository _repository;

        public RegraService(IRegraRepository repository)
        {
            _repository = repository;
        }

        public Regra Atualizar(Regra regra)
        {
            throw new NotImplementedException();
        }

        public Regra Cadastrar(Regra regra)
        {
            throw new NotImplementedException();
        }

        public Regra Consultar(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Regra> Consultar()
        {
            throw new NotImplementedException();
        }

        public Regra Deletar(long id)
        {
            throw new NotImplementedException();
        }
    }
}