using Innoloft.Core.Interfaces;
using Innoloft.Core.Models;

namespace Innoloft.Infrastructure.Data.Repositories
{
    public class ProductTypeRepository : GenericRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(ApplicationDbContext context) : base(context) { }
    }
}
