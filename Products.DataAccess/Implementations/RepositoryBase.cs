using Microsoft.EntityFrameworkCore;
using Products.DataAccess.Abstractions;
using Products.Entity.Models;
using Products.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Products.DataAccess.Implementations
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ProductContext RepositoryContext { get; set; }
        public RepositoryBase(ProductContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            this.RepositoryContext.SaveChanges();
        }
        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            this.RepositoryContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            this.RepositoryContext.SaveChanges();
        }

        public IQueryable<T> GetPaging(PagingParameterss parameters)
        {
            return this.RepositoryContext.Set<T>().AsNoTracking()
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize).AsQueryable();
        }
    }
}
