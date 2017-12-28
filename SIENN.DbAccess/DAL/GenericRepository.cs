﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Abstraction;

namespace SIENN.DbAccess.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _entities;
        private DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public virtual IEnumerable<TEntity> GetRange(int start, int count)
        {
            return _entities.Skip(start).Take(count).ToList();
        }

        public virtual IEnumerable<TEntity> GetRange(int start, int count, Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate).Skip(start).Take(count).ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
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

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }
    }
}
