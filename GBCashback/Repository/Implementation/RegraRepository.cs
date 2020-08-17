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
                decimal? max = _context.Regras.Max(x => x.ValorFinal);
                decimal? min = _context.Regras.Min(x => x.ValorInicial);

                if (max != null && valor > max)
                {
                    return _context.Regras.Where(x => x.ValorFinal == 0).FirstOrDefault();
                }
                else if (min != null && valor < min)
                {
                    return _context.Regras.Where(x => x.ValorInicial == 0).FirstOrDefault();
                }
                else
                {
                    return _context.Regras.Where(x =>
                        x.ValorInicial <= valor
                        && x.ValorFinal > valor
                    ).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw new Exception(Mensagens.NenhumRegistroEncontrado);
            }
        }
    }
}