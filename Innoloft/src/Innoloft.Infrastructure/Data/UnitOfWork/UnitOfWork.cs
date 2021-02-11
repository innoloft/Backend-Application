using Innoloft.Core.Interfaces;
using Innoloft.Infrastructure.Data.Repositories;
using System.Threading.Tasks;

namespace Innoloft.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IProductRepository _products;
        private IProductTypeRepository _productTypes;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IProductRepository Products
            => _products = _products ?? new ProductRepository(_context);

        public IProductTypeRepository ProductTypes
            => _productTypes = _productTypes ?? new ProductTypeRepository(_context);

        public async Task<bool> SaveAsync()
            => await _context.SaveChangesAsync() > 0;

        public void Dispose()
            => _context.Dispose();
    }
}
