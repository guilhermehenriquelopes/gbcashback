using GBCashback.Models;

namespace GBCashback.Repository.Interface
{
    public interface IRevendedorRepository : IRepository<Revendedor>
    {
        Revendedor ConsultarPorCpf(string cpf);
        Revendedor ConsultarPorEmail(string email);
        Revendedor ConsultarPorCpfSenha(string cpf, string senha);
    }
}