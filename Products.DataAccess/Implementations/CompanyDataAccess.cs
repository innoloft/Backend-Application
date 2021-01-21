using Products.DataAccess.Abstractions;
using Products.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.DataAccess.Implementations
{
    public class CompanyDataAccess : RepositoryBase<Company>, ICompanyDataAccess
    {
        public CompanyDataAccess(ProductContext context) : base(context)
        {

        }
    }
}
