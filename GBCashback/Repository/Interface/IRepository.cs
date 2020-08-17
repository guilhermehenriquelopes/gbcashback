using System.Collections.Generic;
using System.Threading.Tasks;

namespace GBCashback.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        TEntity Cadastrar(TEntity entity);
        TEntity Consultar(long id);
        IEnumerable<TEntity> Consultar();
        TEntity Atualizar(TEntity entity);
    }
}