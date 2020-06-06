using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dados.Repository.Base
{
    public interface IBaseRepository<TEntity, IdType>
    {
        Task<int> SaveOrUpdate(TEntity e);

        Task<int> Save(TEntity e);

        Task<int> Update(TEntity e);

        Task<int> Delete(TEntity e);

        Task<int> Delete(IdType e);

        TEntity MergeFromDB(TEntity localCopy);

        TEntity Get(IdType id);

        Task<List<TEntity>> RestorePageAsync(int pageIndex, int pageSize);

        Task<List<TEntity>> GetAllAsync();

        IdType GetPkValue(TEntity e);
    }
}