using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SIENN.DbAccess.Abstraction;
using SIENN.Domain.Abstraction;
using SIENN.Domain.Infrastructure;
using SIENN.Services.Abstraction;

namespace SIENN.Services.Implementation
{
    public abstract class DataService<TEntity, TRepository> : IDataService<TEntity>
        where TEntity : class, IDbEntity, new()
        where TRepository : IGenericRepository<TEntity>
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected TRepository Repository;

        protected DataService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Initialize();
        }

        private void Initialize()
        {
            Initialize(out Repository);
        }

        protected abstract void Initialize(out TRepository repository);

        public virtual TEntity GetById(int id)
        {
            return Repository.Get(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public virtual Page<TEntity> GetPage(PagingReqest request, Expression<Func<TEntity, bool>> filter = null)
        {
            var all = Repository.GetAll();
            var queryable = all.Where(filter ?? (x => true));
            var slice = queryable.OrderBy(t => t.Id)
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize).ToList();
            return new Page<TEntity>
            {
                Items = slice,
                PageSize = request.PageSize,
                CurrentPage = request.PageNumber,
                FoundItems = queryable.Count(),
                TotalItems = all.Count()
            };
        }

        public int Count()
        {
            return Repository.GetAll().Count();
        }

        public virtual void Insert(TEntity item)
        {
            item.Created = DateTimeOffset.UtcNow;
            Repository.Add(item);
            UnitOfWork.Save();
        }

        public virtual void Update(TEntity item)
        {
            item.Updated = DateTimeOffset.UtcNow;
            Repository.Update(item);
            UnitOfWork.Save();
        }

        public virtual void Delete(int id)
        {
            Repository.Remove(id);
            UnitOfWork.Save();
        }

        public virtual void Delete(TEntity item)
        {
            Repository.Remove(item);
            UnitOfWork.Save();
        }
    }
}
