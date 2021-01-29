using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Application.WebAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private Hashtable _repositories;

        public UnitOfWork(DatabaseContext context, IServiceProvider serviceProvider)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                        .MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
