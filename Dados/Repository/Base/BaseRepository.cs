using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dados.Repository.Base
{
    public abstract class BaseRepository<TEntity, IdType> : 
            IBaseRepository<TEntity, IdType> where TEntity : class
    {
        protected readonly ApplicationDBContext _context;

        public BaseRepository(ApplicationDBContext context)
        {
            if (context == null)
                throw new ArgumentException("Context can not be null!");

            this._context = context;
        }

        public abstract TEntity Get(IdType id);
        public abstract IdType GetPkValue(TEntity e);

        public virtual TEntity MergeFromDB(TEntity localCopy)
        {
            var pkValue = GetPkValue(localCopy);
            var objFromDB = Get(pkValue);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + pkValue +
                    " NOT FOUND FOR ENTITY: CONFIGURACAO");

            foreach (var pinfo in typeof(TEntity).GetProperties())
            {
                // Não pode alterar PK!!
                pinfo.SetValue(objFromDB, pinfo.GetValue(localCopy));
            }

            return objFromDB;
        }

        public virtual Task<List<TEntity>> RestorePageAsync(int pageIndex, int pageSize)
        {
            var q = _context.Set<TEntity>()
                         .Skip((pageIndex - 1) * pageSize)
                         .Take(pageSize)
                         .ToListAsync();

            return q;
        }

        public virtual Task SaveOrUpdate(TEntity e)
        {
            if (!Exists(e))
            {
                return Save(e);
            }
            else
            {
                var fromDB = MergeFromDB(e);
                return Update(fromDB);
            }
        }

        public virtual Task Save(TEntity e)
        {
            _context.Set<TEntity>().Add(e);
            return _context.SaveChangesAsync();
        }

        public virtual Task Update(TEntity e)
        {
            _context.Set<TEntity>().Attach(e);
            return _context.SaveChangesAsync();
        }


        public virtual Task Delete(IdType e)
        {
            var item = Get(e);
            return Delete(e);
        }

        public virtual Task Delete(TEntity e)
        {
            var result = _context.Set<TEntity>().Remove(e);
            return _context.SaveChangesAsync();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            var list = _context.Set<TEntity>().ToListAsync();

            return list;
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _context.Set<TEntity>().AsQueryable<TEntity>();
        }

        public bool Exists(TEntity entity)
        {
            return _context.Set<TEntity>().Any(e => e == entity);
        }

        public bool Exists(params object[] keys)
        {
            return _context.Set<TEntity>().Find(keys) != null;
        }
    }
}