using Innoloft.Core.Helpers;
using Innoloft.Core.Interfaces;
using Innoloft.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Innoloft.Infrastructure.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsWithTypeAsync()
        {
            return await _context.Products.Include(t => t.ProductType).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithTypeAsync(PagingParams pagingParams)
        {
            var products = _context.Products.Include(t => t.ProductType).AsQueryable();

            if (!string.IsNullOrEmpty(pagingParams.ProductType))
                products = products.Where(p => p.ProductType.Name == pagingParams.ProductType);

            return await PagedList<Product>.CreateAsync(products, pagingParams.Number, pagingParams.PageSize);
        }

        public async Task<Product> GetProductWithTypeByIdAsync(int id)
        {
            return await _context.Products.Include(t => t.ProductType).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
