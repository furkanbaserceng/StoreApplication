using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T> 
    {
        IQueryable<T> GetAll(bool trackChanges, Expression<Func<T,bool>> expression=null);
        T? GetByCondition(bool trackChanges, Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
    }
}
