using System.Collections.Generic;
using GBCashback.Models;
using GBCashback.Repository.Interface;
using GBCashback.Services.Interface;

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
            return _repository.Atualizar(regra);
        }

        public Regra Cadastrar(Regra regra)
        {
            return _repository.Cadastrar(regra);
        }

        public IEnumerable<Regra> Consultar()
        {
            return _repository.Consultar();
        }

        public Regra Consultar(long id)
        {
            return _repository.Consultar(id);
        }

        public Regra Deletar(long id)
        {
            return _repository.Deletar(id);
        }
    }
}