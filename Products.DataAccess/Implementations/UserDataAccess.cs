using Products.DataAccess.Abstractions;
using Products.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.DataAccess.Implementations
{
    public class UserDataAccess : RepositoryBase<User>, IUserDataAccess
    {
        public UserDataAccess(ProductContext context) : base(context)
        {

        }
    }
}
