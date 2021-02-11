using Innoloft.Core.Helpers;
using Innoloft.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Innoloft.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsWithTypeAsync();
        Task<IEnumerable<Product>> GetProductsWithTypeAsync(PagingParams pagingParams);
        Task<Product> GetProductWithTypeByIdAsync(int id);
    }
}
