using Products.DataAccess.Abstractions;
using Products.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.DataAccess.Implementations
{
    public class ProductDataAccess : RepositoryBase<Product>, IProductDataAccess
    {
        public ProductDataAccess(ProductContext context) : base(context)
        {

        }
    }
}
