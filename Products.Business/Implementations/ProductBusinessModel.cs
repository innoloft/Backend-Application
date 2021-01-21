using Products.Business.Abstractions;
using Products.DataAccess.Abstractions;
using Products.Entity.Models;
using Products.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Products.Business.Implementations
{
    public class ProductBusinessModel: IProductBusinessModel
    {
        public IProductDataAccess DataAccess { get; set; }
        public ProductBusinessModel(IProductDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }
        public IQueryable<Product> FindAll()
        {
            return DataAccess.FindAll();
        }

        public IQueryable<Product> FindByCondition(Expression<Func<Product, bool>> expression)
        {
            return this.DataAccess.FindByCondition(expression);
        }

        public void Create(Product entity)
        {
            this.DataAccess.Create(entity);
        }

        public void Update(Product entity)
        {
            this.DataAccess.Update(entity);
        }

        public void Delete(Product entity)
        {
            this.DataAccess.Delete(entity);
        }

        public IQueryable<Product> GetPaging(PagingParameterss parameters)
        {
            return this.DataAccess.GetPaging(parameters);
        }
    }
}
