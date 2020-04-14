using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dados.Repository.Base
{
    public interface IBaseRepository<TEntity, IdType>
    {
        Task SaveOrUpdate(TEntity e);

        Task Save(TEntity e);

        Task Update(TEntity e);

        Task Delete(TEntity e);

        Task Delete(IdType e);

        TEntity MergeFromDB(TEntity localCopy);

        TEntity Get(IdType id);

        Task<List<TEntity>> RestorePageAsync(int pageIndex, int pageSize);

        Task<List<TEntity>> GetAllAsync();

        IdType GetPkValue(TEntity e);
    }
}