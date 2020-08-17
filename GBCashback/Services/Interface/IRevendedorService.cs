using System.Collections.Generic;
using GBCashback.Models;

namespace GBCashback.Services.Interface
{
    public interface IRevendedorService
    {
        Revendedor Cadastrar(Revendedor revendedor);
        Revendedor Atualizar(Revendedor revendedor);
        Revendedor Consultar(long id);
        Revendedor Deletar(long id);
        Revendedor Ativar(long id);
        Revendedor Inativar(long id);
        IEnumerable<Revendedor> Consultar();        
    }
}