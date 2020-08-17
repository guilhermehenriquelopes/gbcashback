using System.Collections.Generic;
using GBCashback.Models;

namespace GBCashback.Services.Interface
{
    public interface ICompraService
    {
        Compra Cadastrar(Compra compra);
        Compra Atualizar(Compra compra);        
        Compra Consultar(string cpf, string codigo);
        Compra Deletar(long id);
        IEnumerable<Compra> Consultar(string cpf);
        IEnumerable<Compra> Consultar();
        Compra Ativar(string cpf, string codigo);        
    }
}