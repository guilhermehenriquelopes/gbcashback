using System;
using System.Linq;
using GBCashback.Models;
using GBCashback.Models.Base;
using GBCashback.Repository.Interface;
using GBCashback.Util;

namespace GBCashback.Repository.Implementation
{
    public class RegraRepository : Repository<Regra>, IRegraRepository
    {
        private readonly DatabaseContext _context;

        public RegraRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public Regra Consultar(decimal valor)
        {
            try
            {
                return _context.Regras.Where(x =>
                    x.ValorInicial <= valor
                    && x.ValorFinal > valor
                ).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception(Mensagens.NenhumRegistroEncontrado);
            }
        }
    }
}