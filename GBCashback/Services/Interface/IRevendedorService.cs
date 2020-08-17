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
        Revendedor Ativar(string cpf);        
        IEnumerable<Revendedor> Consultar();    
        Revendedor ConsultarPorCpfSenha(string cpf, string senha);
    }
}