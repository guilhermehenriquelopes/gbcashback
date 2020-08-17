using GBCashback.Models;

namespace GBCashback.Repository.Interface
{
    public interface ICompraRepository : IRepository<Compra>
    {
        Compra ConsultarPorCpfCodigo(string cpf, string codigo);
    }
}