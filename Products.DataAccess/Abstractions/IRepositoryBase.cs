using Products.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Products.DataAccess.Abstractions
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> GetPaging(PagingParameterss parameters);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
