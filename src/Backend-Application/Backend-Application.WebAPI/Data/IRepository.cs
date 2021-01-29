using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Application.WebAPI.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Table { get; }
        public TEntity Get(object id);

        public TEntity Update(TEntity entity);

        public TEntity Add(TEntity entity);

        public void AddRange(List<TEntity> entities);

        public void Delete(TEntity entity);
    }
}
