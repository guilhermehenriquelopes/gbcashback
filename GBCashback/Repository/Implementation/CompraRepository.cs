using System;
using System.Collections.Generic;
using System.Linq;
using GBCashback.DTO;
using GBCashback.Enums;
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

        public AcumuladoDTO Acumulado(string cpf)
        {
            try
            {
                var response = new AcumuladoDTO() { CPF = cpf, Credit = 0 };

                decimal? acumulado = _context.Compras
                .Where(x => x.CPF == cpf && x.Status == EnumStatus.Aprovado)
                .Sum(x => x.CashbackValor);

                if (acumulado != null)
                    response.Credit = acumulado.Value;

                return response;
            }
            catch (Exception)
            {
                throw new Exception(Mensagens.NenhumRegistroEncontrado);
            }
        }
    }
}