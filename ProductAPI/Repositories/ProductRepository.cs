namespace ProductAPI.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Distributed;
    using Newtonsoft.Json;
    using ProductAPI.Interfaces;
    using ProductAPI.Models;

    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext dbContext;
        private readonly IDistributedCache cache;

        public ProductRepository(
            ProductDBContext injectedDBContext,
            IDistributedCache injectedCache)
        {
            dbContext = injectedDBContext;
            cache = injectedCache;
        }

        public async Task CreateProductAsync(Product product, int ownerId)
        {
            User owner = new User() { id = ownerId };
            product.owner = owner;

            dbContext.Attach(owner);
            await dbContext.AddAsync<Product>(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            dbContext.Update(product);
            dbContext.Entry(product).Property(p => p.ownerId).IsModified = false;
            await dbContext.SaveChangesAsync();
            await cache.RemoveAsync(product.id.ToString());
        }

        public async Task DeleteProductAsync(int id)
        {
            dbContext.Products.Remove(dbContext.Products.Find(id));

            await dbContext.SaveChangesAsync();
            await cache.RemoveAsync(id.ToString());
        }

        public async Task<List<Product>> GetProductsAsync(ProductRequestModel requestModel)
        {
            List<Product> products = await dbContext.Products
                                                .Where(p =>
                                                    requestModel.filterTypes.Count == 0 || requestModel.filterTypes.Contains(p.type))
                                                .Skip((requestModel.pageNum - 1) * requestModel.pageSize)
                                                .Take(requestModel.pageSize)
                                                .Include(products =>  products.owner)
                                                .Include(products => products.owner.address)
                                                .Include(products => products.owner.company)
                                                .ToListAsync();

            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            Product product;
            string serializedProduct;
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            serializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            var encodedProduct = await cache.GetAsync(id.ToString());

            if(encodedProduct != null)
            {
                serializedProduct = Encoding.UTF8.GetString(encodedProduct);
                product = JsonConvert.DeserializeObject<Product>(serializedProduct);
            }
            else
            {
                product = await dbContext.Products
                            .Where(products => products.id == id)
                            .Include(products =>  products.owner)
                            .Include(products => products.owner.address)
                            .Include(products => products.owner.company)
                            .FirstOrDefaultAsync();
                
                if(product != null)
                {
                    serializedProduct = JsonConvert.SerializeObject(product, serializerSettings);
                    encodedProduct = Encoding.UTF8.GetBytes(serializedProduct);
                    await cache.SetAsync(id.ToString(), encodedProduct);
                }
            }

            return product;
        }
    }
}