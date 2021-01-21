using Products.Entity.Models;
using Products.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Products.Business.Abstractions
{
    public interface ICompanyBusinessModel
    {
        IQueryable<Company> FindAll();
        IQueryable<Company> FindByCondition(Expression<Func<Company, bool>> expression);
        void Create(Company entity);
        void Update(Company entity);
        void Delete(Company entity);
        IQueryable<Company> GetPaging(PagingParameterss parameters);
    }
}
