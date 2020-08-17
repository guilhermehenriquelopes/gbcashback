using System.Collections.Generic;
using GBCashback.Models;

namespace GBCashback.Services.Interface
{
    public interface ICompraService
    {
        Compra Cadastrar(Compra compra);
        Compra Atualizar(Compra compra);
        Compra Consultar(long id);
        Compra Deletar(long id);
        IEnumerable<Compra> Consultar();
    }
}