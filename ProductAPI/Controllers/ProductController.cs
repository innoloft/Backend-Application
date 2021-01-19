namespace ProductAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ProductAPI.Interfaces;
    using ProductAPI.Models;

    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository productRepository;

        private readonly IMapper mapper;

        public ProductController(
            IProductRepository injectedProductRepo,
            IMapper injectedMapper
        )
        {
            productRepository = injectedProductRepo;
            mapper = injectedMapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetProducts([FromQuery]ProductRequestModel requestModel)
        {
            List<Product> products = await productRepository.GetProductsAsync(requestModel);

            return StatusCode(StatusCodes.Status200OK, products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetProductById(int id)
        {
            Product product = await productRepository.GetProductByIdAsync(id);

            return StatusCode(StatusCodes.Status200OK, product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateProduct([FromBody]ProductCreationModel product)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            await productRepository.CreateProductAsync(mapper.Map<Product>(product), product.userId);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost("update")]
        [Authorize]
        public async Task<ActionResult> UpdateProduct([FromBody]ProductUpdateModel updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }


            int userId =
                Int32.Parse(HttpContext.User.Claims.FirstOrDefault((claim) => claim.Type == ClaimTypes.Sid).Value);
            Product product = await productRepository.GetProductByIdAsync(updatedProduct.id);

            if(product.owner.id == userId)
            {
                await productRepository.UpdateProductAsync(mapper.Map<Product>(updatedProduct));
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            int userId =
                Int32.Parse(HttpContext.User.Claims.FirstOrDefault((claim) => claim.Type == ClaimTypes.Sid).Value);
            Product product = await productRepository.GetProductByIdAsync(id);
            
            if(product.owner.id == userId)
            {
                await productRepository.DeleteProductAsync(id);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
