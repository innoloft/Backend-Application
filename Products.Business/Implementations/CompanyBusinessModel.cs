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
    public class CompanyBusinessModel: ICompanyBusinessModel
    {
        public ICompanyDataAccess DataAccess { get; set; }
        public CompanyBusinessModel(ICompanyDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }
        public IQueryable<Company> FindAll()
        {
            return DataAccess.FindAll();
        }

        public IQueryable<Company> FindByCondition(Expression<Func<Company, bool>> expression)
        {
            return this.DataAccess.FindByCondition(expression);
        }

        public void Create(Company entity)
        {
            this.DataAccess.Create(entity);
        }

        public void Update(Company entity)
        {
            this.DataAccess.Update(entity);
        }

        public void Delete(Company entity)
        {
            this.DataAccess.Delete(entity);
        }

        public IQueryable<Company> GetPaging(PagingParameterss parameters)
        {
            return this.DataAccess.GetPaging(parameters);
        }
    }
}
