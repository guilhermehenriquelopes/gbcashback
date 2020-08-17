using System.Collections.Generic;
using GBCashback.DTO;
using GBCashback.Models;

namespace GBCashback.Repository.Interface
{
    public interface ICompraRepository : IRepository<Compra>
    {
        Compra ConsultarPorCpfCodigo(string cpf, string codigo);
        IEnumerable<Compra> ConsultarPorCpf(string cpf);
        AcumuladoDTO Acumulado(string cpf);
    }
}