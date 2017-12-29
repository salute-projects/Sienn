using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SIENN.Domain.Abstraction;
using SIENN.Domain.Infrastructure;

namespace SIENN.Services.Abstraction
{
    public interface IDataService<T> where T : class, IDbEntity
    {
        T GetById(int id);
        Page<T> GetPage(PagingReqest request, Expression<Func<T, bool>> filter = null);
        IEnumerable<T> GetAll();
        int Count();
        void Insert(T item);
        void Update(T item);
        void Delete(int id);
        void Delete(T item);
    }
}