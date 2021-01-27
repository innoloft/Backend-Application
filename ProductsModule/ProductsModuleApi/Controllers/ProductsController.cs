using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductModuleDataAccess.Interfaces;
using ProductModuleDataAccess.Models;
using ProductsModuleApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsModuleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _products;
        private readonly IMapper _mapper;

        public ProductsController(IProductsService products, IMapper mapper)
        {
            _products = products;
            _mapper = mapper;
        }

        [HttpGet("allproducts")]
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Products>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllProducts()
        {
            var allProducts = await _products.GetAllProducts();

            return Ok(allProducts);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _products.GetById(id);

            if (product == null)
                return BadRequest($"Product with id : {id} doesn't exit");

            return Ok(product);
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel createProductModel)
        {
            var productToCreate = _mapper.Map<Products>(createProductModel);

            var productCreated = await _products.CreateProduct(productToCreate);

            if (productCreated == null)
                return BadRequest("Error occured please check details and try again");

            var productCreatedFullDetails = await _products.GetById(productCreated.productsid);

            return CreatedAtAction(nameof(GetProduct), new { id = productCreated.productsid }, productCreatedFullDetails);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _products.GetById(id);

            if (product == null)
                return BadRequest($"Product with id : {id} doesn't exit");

            await _products.DeleteProduct(product);

            return Ok("Deleted successfully");
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductModel createProductModel)
        {
            var productToUpdate = _mapper.Map<Products>(createProductModel);
            productToUpdate.productsid = id;
            var updatedProduct = await _products.UpdateProduct(productToUpdate);

            if (updatedProduct == null)
                return BadRequest("Error occured please check details and try again");

            var updatedProductFullDetails = await _products.GetById(id);

            return Ok(updatedProductFullDetails);
        }
    } 
}
