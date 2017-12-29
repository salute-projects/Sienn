using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Abstraction;

namespace SIENN.DbAccess.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _entities;

        public GenericRepository(DbContext context)
        {
            _entities = context.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities;
        }

        public virtual IQueryable<TEntity> GetRange(int start, int count)
        {
            return _entities.Skip(start).Take(count);
        }

        public virtual IQueryable<TEntity> GetRange(int start, int count, Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate).Skip(start).Take(count);
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public virtual int Count()
        {
            return _entities.Count();
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void Remove(int id)
        {
            var entity = Get(id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }

        public virtual void Remove(TEntity item)
        {
            _entities.Remove(item);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }
    }
}
