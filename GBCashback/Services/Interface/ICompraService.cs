using System.Collections.Generic;
using GBCashback.DTO;
using GBCashback.Models;

namespace GBCashback.Services.Interface
{
    public interface ICompraService
    {
        Compra Cadastrar(Compra compra);
        Compra Atualizar(Compra compra);        
        Compra Deletar(string cpf, string codigo);
        IEnumerable<Compra> Consultar(string cpf);
        IEnumerable<Compra> Consultar();
        Compra Ativar(string cpf, string codigo);
        AcumuladoDTO Acumulado(string cpf);
    }
}