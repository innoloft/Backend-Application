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
    public class AddressBusinessModel: IAddressBusinessModel
    {
        public IAddressDataAccess DataAccess { get; set; }
        public AddressBusinessModel(IAddressDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }
        public IQueryable<Address> FindAll()
        {
            return DataAccess.FindAll();
        }

        public IQueryable<Address> FindByCondition(Expression<Func<Address, bool>> expression)
        {
            return this.DataAccess.FindByCondition(expression);
        }

        public void Create(Address entity)
        {
            this.DataAccess.Create(entity);
        }

        public void Update(Address entity)
        {
            this.DataAccess.Update(entity);
        }

        public void Delete(Address entity)
        {
            this.DataAccess.Delete(entity);
        }

        public IQueryable<Address> GetPaging(PagingParameterss parameters)
        {
            return this.DataAccess.GetPaging(parameters);
        }
    }
}
