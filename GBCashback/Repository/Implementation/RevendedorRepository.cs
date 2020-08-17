using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCashback.Models;
using GBCashback.Models.Base;
using GBCashback.Repository.Interface;
using GBCashback.Util;

namespace GBCashback.Repository.Implementation
{
    public class RevendedorRepository : Repository<Revendedor>, IRevendedorRepository
    {
        private readonly DatabaseContext _context;

        public RevendedorRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public Revendedor ConsultarPorCpf(string cpf)
        {
           try
            {
                return _context.Revendedores.Where(x => x.CPF == cpf).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception(Mensagens.NenhumRegistroEncontrado);
            }
        }

        public Revendedor ConsultarPorEmail(string email)
        {
           try
            {
                return _context.Revendedores.Where(x => x.Email == email).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception(Mensagens.NenhumRegistroEncontrado);
            }
        }
    }
}