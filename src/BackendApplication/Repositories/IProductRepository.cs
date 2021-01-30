using BackendApplication.Models;
using BackendApplication.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendApplication.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetProductsAsync(GetFilter filter);
        Task<ProductDto> GetProductAsync(int id);
        Task<int> AddProductAsync(ProductInputDto input);
        Task UpdateProductAsync(ProductInputDto input);
        Task DeleteProductAsync(int productId, int tokenUserId);
    }
}