using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dados.Repository.Base
{
    public interface IBaseRepository<TEntity>
    {
        Task<int> Add(TEntity e);

        Task<int> Update(TEntity e);

        Task<int> Delete(TEntity e);

        Task<int> Delete(long id);

        TEntity Get(long id);

        Task<List<TEntity>> GetAllAsync();
    }
}