using System;
using System.Collections.Generic;
using System.Linq;
using GBCashback.Models;
using GBCashback.Models.Base;
using GBCashback.Repository.Interface;
using GBCashback.Util;

namespace GBCashback.Repository.Implementation
{
    public class CompraRepository : Repository<Compra>, ICompraRepository
    {
        private readonly DatabaseContext _context;

        public CompraRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }


        public Compra ConsultarPorCpfCodigo(string cpf, string codigo)
        {
            try
            {
                return _context.Compras.Where(x =>
                    x.CPF == cpf
                    && x.Codigo == codigo
                ).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception(Mensagens.NenhumRegistroEncontrado);
            }
        }

        public IEnumerable<Compra> ConsultarPorCpf(string cpf)
        {
            try
            {
                return _context.Compras.Where(x =>
                    x.CPF == cpf
                ).ToList();
            }
            catch (Exception)
            {
                throw new Exception(Mensagens.NenhumRegistroEncontrado);
            }
        }
    }
}