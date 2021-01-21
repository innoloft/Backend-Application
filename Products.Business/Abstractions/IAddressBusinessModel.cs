using Products.Entity.Models;
using Products.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Products.Business.Abstractions
{
    public interface IAddressBusinessModel
    {
        IQueryable<Address> FindAll();
        IQueryable<Address> FindByCondition(Expression<Func<Address, bool>> expression);
        void Create(Address entity);
        void Update(Address entity);
        void Delete(Address entity);
        IQueryable<Address> GetPaging(PagingParameterss parameters);
    }
}
