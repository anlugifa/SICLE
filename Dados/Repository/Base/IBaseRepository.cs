using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dados.Repository.Base
{
    public interface IBaseRepository<TEntity, IdType>
    {
        void SaveOrUpdate(TEntity e);

        void Save(TEntity e);

        void Update(TEntity e);

        void Delete(TEntity e);

        void Delete(IdType e);

        TEntity MergeFromDB(TEntity localCopy);

        TEntity Get(IdType id);

        Task<List<TEntity>> RestorePageAsync(int pageIndex, int pageSize);

        Task<List<TEntity>> GetAllAsync();

        IdType GetPkValue(TEntity e);
    }
}