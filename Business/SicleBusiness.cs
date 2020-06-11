using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dados.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Sicle.Logs.Bases;

namespace Sicle.Business
{
    public class SicleBusiness<TEntity> where TEntity : class
    {

        // public virtual TEntity MergeFromDB(TEntity localCopy)
        // {
        //     var pkValue = GetPkValue(localCopy);
        //     var objFromDB = Get(pkValue);

        //     if (objFromDB == null)
        //         throw new ArgumentException("ERRO: ID " + pkValue +
        //             " NOT FOUND FOR ENTITY: " + typeof(TEntity).Name);

        //     foreach (var pinfo in typeof(TEntity).GetProperties())
        //     {
        //         // Não pode alterar PK!!
        //         pinfo.SetValue(objFromDB, pinfo.GetValue(localCopy));
        //     }

        //     return objFromDB;
        // }

        public virtual TEntity Get(long id)
        {
            using (var repositorio = new BaseRepository<TEntity>())
            {
                return repositorio.Get(id);
            }
        }

        public virtual TEntity MergeFromDB(TEntity localCopy)
        {
            return localCopy;
        }

        public virtual async Task<bool> SaveOrUpdate(TEntity model)
        {
            try
            {
                using (BaseRepository<TEntity> repo = new BaseRepository<TEntity>())
                {
                    int count = 0;
                    if (!repo.Exists(model))
                    {
                        count = await repo.Add(model);
                    }
                    else
                    {
                        var fromDb = MergeFromDB(model);
                        count = await repo.Update(fromDb);
                    }

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                new SicleException(ex.Message, ex).LogarErro();
            }

            return false;
        }

        public virtual async Task<bool> Add(TEntity model)
        {
            try
            {
                using (var repo = new BaseRepository<TEntity>())
                {
                    int count = await repo.Add(model); 
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                new SicleException(ex.Message, ex).LogarErro();
            }

            return false;
        }

        public virtual async Task<bool> Update(TEntity model)
        {
            try
            {
                using (var repo = new BaseRepository<TEntity>())
                {
                    int count = await repo.Update(model); 
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                new SicleException(ex.Message, ex).LogarErro();
            }

            return false;
        }


        public virtual async Task<bool> Delete(TEntity model)
        {
            try
            {
                using (var repositorio = new BaseRepository<TEntity>())
                {
                    int count = await repositorio.Delete(model);
                    if (count > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                new SicleException(ex.Message, ex).LogarErro();
            }
            return false;
        }

        public virtual async Task<bool> Delete(long id)
        {
            try
            {
                using (var repositorio = new BaseRepository<TEntity>())
                {
                    int count = await repositorio.Delete(id);
                    if (count > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                new SicleException(ex.Message, ex).LogarErro();
            }
            return false;
        }

        public virtual async Task<List<TEntity>> RestorePageAsync(int pageIndex, int pageSize)
        {
            
            using (var repo = new BaseRepository<TEntity>())
            {
                var q = repo.AsQueryable()
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

                return await q;
            }
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return new BaseRepository<TEntity>().AsQueryable();
        }        

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return new BaseRepository<TEntity>().GetAllAsync();
        }
    }
}
