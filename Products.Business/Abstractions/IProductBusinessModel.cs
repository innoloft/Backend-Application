using Products.Entity.Models;
using Products.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Products.Business.Abstractions
{
    public interface IProductBusinessModel
    {
        IQueryable<Product> FindAll();
        IQueryable<Product> FindByCondition(Expression<Func<Product, bool>> expression);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        IQueryable<Product> GetPaging(PagingParameterss parameters);
    }
}
