using System.Collections.Generic;
using GBCashback.Models;

namespace GBCashback.Services.Interface
{
    public interface IRegraService
    {
        Regra Cadastrar(Regra regra);
        Regra Atualizar(Regra regra);                
        Regra Deletar(long id);
        IEnumerable<Regra> Consultar();
        Regra Consultar(long id);
    }
}