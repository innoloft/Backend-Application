using AutoMapper;
using BackendApplication.Clients;
using BackendApplication.Context;
using BackendApplication.Models;
using BackendApplication.Models.Dto;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApplication.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;
        private readonly IUserClient userClient;
        private readonly ILogger<ProductRepository> logger;


        public ProductRepository(ApplicationContext context, IMapper mapper, IUserClient userClient, ILogger<ProductRepository> logger)
        {
            this.context = context;
            this.mapper = mapper;
            this.userClient = userClient;
            this.logger = logger;
        }

        public async Task<int> AddProductAsync(ProductInputDto input)
        {
            input.Id = string.Empty;
            var product = mapper.Map<Product>(input);
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return product.Id;
        }

        public async Task DeleteProductAsync(int productId, int tokenUserId)
        {

            var product = context.Products.Where(x => (x.Id == productId)).FirstOrDefault();
            if (product == null)
            {
                logger.LogInformation("Product {0} was not found", productId);
                throw new RequestException("Your product was not found", 404);
            }

            if (tokenUserId != product.UserId)
            {
                logger.LogInformation("Product {0} does not belong to {1}", productId, tokenUserId);
                throw new RequestException("Forbidden", 403);
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var product = context.Products.Where(s => s.Id == id).FirstOrDefault();
            if (product == null)
            {
                logger.LogInformation("Product {0} was not found", id);
                throw new RequestException("Your product was not found", 404);
            }
            var res = mapper.Map<ProductDto>(product);
            var user = await userClient.GetUserInfoAsync(res.User.Id).ConfigureAwait(false);
            res.User = mapper.Map<ShortUserDto>(user);
            return res;
        }

        public async Task<List<ProductDto>> GetProductsAsync(GetFilter filter)
        {
            var products = context.Products
                .Where(x => filter.Type.Contains(x.Type))
                .Skip(filter.Skip)
                .Take(filter.Take)
                .ToList();

            var users = products.Select(x => x.UserId).ToList();
            var tasks = new List<Task<UserDto>>();
            foreach (var user in users)
            {
                tasks.Add(userClient.GetUserInfoAsync(user));
            }
            await Task.WhenAll(tasks.ToArray()).ConfigureAwait(false);
            var usersDtos = tasks.Select(x => x.Result).ToList();

            var result = mapper.Map<List<ProductDto>>(products);
            result.ForEach(x => x.User = mapper.Map<ShortUserDto>(usersDtos.FirstOrDefault(s => s.Id == x.User.Id)));

            return result;
        }

        public async Task UpdateProductAsync(ProductInputDto input)
        {
            var product = mapper.Map<Product>(input);
            var dbProduct = context.Products.Where(x => (x.Id == product.Id && x.UserId == product.UserId)).FirstOrDefault();
            if (dbProduct == null)
            {
                logger.LogInformation("Product {0} was not found", product.Id);
                throw new RequestException("Your product was not found", 404);
            }

            dbProduct.Description = product.Description;
            dbProduct.Title = product.Title;
            dbProduct.Type = product.Type;

            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
