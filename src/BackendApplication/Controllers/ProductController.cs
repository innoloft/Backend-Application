using BackendApplication.Models;
using BackendApplication.Models.Dto;
using BackendApplication.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery]GetFilter filter)
        {
            List <ProductDto> products = await productRepository.GetProductsAsync(filter).ConfigureAwait(false);
            return this.Ok(products);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            ProductDto product = await productRepository.GetProductAsync(id).ConfigureAwait(false);
            return this.Ok(product);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] ProductInputDto input)
        {
            int id = await productRepository.AddProductAsync(input).ConfigureAwait(false);
            return this.Ok(new { productId = id });
        }

        [Authorize]
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] ProductInputDto input)
        {
            if (this.User.Identity.Name != input.UserId.ToString())
                return this.Forbid();

            await productRepository.UpdateProductAsync(input).ConfigureAwait(false);
            return this.Ok(new { message = "Your product was changed"});
        }

        [Authorize]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int productId)
        {
            var tokenUserId = int.Parse(this.User.Identity.Name);
            await productRepository.DeleteProductAsync(productId, tokenUserId).ConfigureAwait(false);

            return this.Ok(new { message = "Your product was removed" });
        }
    }
}
