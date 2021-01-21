using Products.DataAccess.Abstractions;
using Products.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.DataAccess.Implementations
{
    public class AddressDataAccess : RepositoryBase<Address>, IAddressDataAccess
    {
        public AddressDataAccess(ProductContext context) : base(context)
        {

        }
    }
}
