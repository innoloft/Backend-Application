using AutoMapper;
using Innoloft.Core.DTOs;
using Innoloft.Core.Helpers;
using Innoloft.Core.Interfaces;
using Innoloft.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Innoloft.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRequestService _userRequestService;
        private readonly IMapper _mapper;

        public ProductsController(
            IUnitOfWork unitOfWork,
            IUserRequestService userRequestService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRequestService = userRequestService;
            _mapper = mapper;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] PagingParams pagingParams)
        {
            var products = await _unitOfWork.Products.GetProductsWithTypeAsync(pagingParams);
            var usersDto = await _userRequestService.GetUsers();
            var productsDto = _mapper.Map<List<ProductDetailDto>>(products);

            productsDto.ForEach(p => p.ContactPerson = usersDto.FirstOrDefault(
                u => u.Id == products.FirstOrDefault(pp => pp.Id == p.Id).UserId));

            return Ok(productsDto);
        }

        // GET: api/products/1
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _unitOfWork.Products.GetProductWithTypeByIdAsync(id);
            var userDto = await _userRequestService.GetUser(product.UserId);

            var productDto = _mapper.Map<ProductDetailDto>(product);
            productDto.ContactPerson = userDto;

            return Ok(productDto);
        }

        // POST: api/products/1
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);

            await _unitOfWork.Products.AddAsync(product);

            if (await _unitOfWork.SaveAsync())
            {
                var productToReturn = _mapper.Map<ProductListDto>(product);
                return CreatedAtRoute("GetProduct", new { id = product.Id }, productToReturn);
            }

            throw new Exception("Creating product failed on save");
        }

        // PUT: api/products/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (currentUserId != product.UserId)
                return Unauthorized();

            _mapper.Map(productUpdateDto, product);

            _unitOfWork.Products.Update(product);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Updating product {id} failed to save");
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (currentUserId != product.UserId)
                return Unauthorized();

            _unitOfWork.Products.Remove(product);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Deleting product {id} failed on save");
        }
    }
}
