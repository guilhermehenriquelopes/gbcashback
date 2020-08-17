using GBCashback.Models;

namespace GBCashback.Repository.Interface
{
    public interface IRegraRepository : IRepository<Regra>
    {
        Regra Consultar(decimal min);
    }
}