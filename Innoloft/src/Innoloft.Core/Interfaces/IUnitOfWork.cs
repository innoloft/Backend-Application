using System;
using System.Threading.Tasks;

namespace Innoloft.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IProductTypeRepository ProductTypes { get; }
        Task<bool> SaveAsync();
    }
}
