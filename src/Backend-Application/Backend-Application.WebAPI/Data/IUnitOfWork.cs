using System;
using System.Threading.Tasks;

namespace Backend_Application.WebAPI.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        int Complete();

        Task<int> CompleteAsync();
    }
}
