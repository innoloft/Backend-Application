using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend_Application.WebAPI.Data
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DatabaseContext _context;

        public IQueryable<TEntity> Table => _context.Set<TEntity>();


        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>()
                .Add(entity).Entity;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>()
                .Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return entity;
        }

        public void AddRange(List<TEntity> entities)
        {
            _context.AddRange(entities);
        }

        public TEntity Get(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }
    }
}
