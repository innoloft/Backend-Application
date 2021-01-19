namespace ProductAPI.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ProductAPI.Models;

    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductsAsync(ProductRequestModel requestModel);
        Task CreateProductAsync(Product product, int ownerId);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}