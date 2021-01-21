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
    public class UserBusinessModel: IUserBusinessModel
    {
        public IUserDataAccess DataAccess { get; set; }
        public UserBusinessModel(IUserDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }
        public IQueryable<User> FindAll()
        {
            return DataAccess.FindAll();
        }

        public IQueryable<User> FindByCondition(Expression<Func<User, bool>> expression)
        {
            return this.DataAccess.FindByCondition(expression);
        }

        public void Create(User entity)
        {
            this.DataAccess.Create(entity);
        }

        public void Update(User entity)
        {
            this.DataAccess.Update(entity);
        }

        public void Delete(User entity)
        {
            this.DataAccess.Delete(entity);
        }

        public IQueryable<User> GetPaging(PagingParameterss parameters)
        {
            return this.DataAccess.GetPaging(parameters);
        }
    }
}
