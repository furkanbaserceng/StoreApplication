﻿using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll(bool trackChanges, Expression<Func<T, bool>> expression = null)
        {
            //return trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
            if (trackChanges != true)
            {
                if (expression != null)
                {
                    return _context.Set<T>().Where(expression).AsNoTracking();
                }

                return _context.Set<T>().AsNoTracking();
            }
            else
            {
                if(expression != null)
                {
                    return _context.Set<T>().Where(expression);
                }
                return _context.Set<T>();
            }
        }

        public T? GetByCondition(bool trackChanges, Expression<Func<T, bool>> expression)
        {
            return trackChanges ? _context.Set<T>().SingleOrDefault(expression) : _context.Set<T>().AsNoTracking().SingleOrDefault(expression);
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
