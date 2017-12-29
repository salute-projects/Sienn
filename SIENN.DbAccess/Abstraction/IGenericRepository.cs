using System;
using System.Linq;
using System.Linq.Expressions;

namespace SIENN.DbAccess.Abstraction
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetRange(int start, int count);
        IQueryable<TEntity> GetRange(int start, int count, Expression<Func<TEntity, bool>> predicate);

        int Count();

        void Add(TEntity entity);
        void Remove(int id);
        void Remove(TEntity item);
        void Update(TEntity entity);
    }
}