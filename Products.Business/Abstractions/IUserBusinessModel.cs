using Products.Entity.Models;
using Products.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Products.Business.Abstractions
{
    public interface IUserBusinessModel
    {
        IQueryable<User> FindAll();
        IQueryable<User> FindByCondition(Expression<Func<User, bool>> expression);
        void Create(User entity);
        void Update(User entity);
        void Delete(User entity);
        IQueryable<User> GetPaging(PagingParameterss parameters);
    }
}
