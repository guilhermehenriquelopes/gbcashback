using System.Collections.Generic;
using GBCashback.Models;

namespace GBCashback.Services.Interface
{
    public interface IRegraService
    {
        Regra Cadastrar(Regra regra);
        Regra Atualizar(Regra regra);
        Regra Consultar(long id);
        Regra Deletar(long id);
        IEnumerable<Regra> Consultar();
    }
}