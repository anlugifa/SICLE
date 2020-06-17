using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dados.Repository.Base
{
    public class BaseRepository<TEntity> : IDisposable,
            IBaseRepository<TEntity> where TEntity : class
    {
        protected ApplicationDBContext _context;

        public BaseRepository()
        {
            this._context = new ApplicationDBContext();
        }                

        public virtual Task<int> Add(TEntity e)
        {
            _context.Set<TEntity>().Add(e);
            return _context.SaveChangesAsync();
        }

        public virtual Task<int> Update(TEntity e)
        {
            _context.Set<TEntity>().Attach(e);
            return _context.SaveChangesAsync();
        }

        public virtual TEntity Get(long Id)
        {
            return _context.Set<TEntity>().Find(Id);
        }

        public virtual Task<int> Delete(long id)
        {
            var item = Get(id);
            return Delete(item);
        }

        public virtual Task<int> Delete(TEntity e)
        {
            var result = _context.Set<TEntity>().Remove(e);
            return _context.SaveChangesAsync();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            var list = _context.Set<TEntity>().ToListAsync();

            return list;
        }

        public virtual List<TEntity> GetAll()
        {
            var list = _context.Set<TEntity>().ToList();

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

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}