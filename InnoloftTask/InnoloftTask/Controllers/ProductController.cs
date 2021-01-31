using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InnoloftTask.Models;
using AutoMapper;

namespace InnoloftTask.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;
        private readonly IMapper _mapper;

        public ProductController(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: products?pageNumber=2&pageSize=1&typeIds=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProduct(
            int pageNumber, int pageSize, [FromQuery] int[] typeIds)
        {

            //List<int> typeIds = new List<int>();
            //typeIds.Add(1);
            //typeIds.Add(2);

            var products = await _context.Product
                .Where(p => typeIds.Contains(p.TypeId))
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize).ToListAsync();

            List<ProductDTO> productDTOs = new List<ProductDTO>();

            foreach (Product p in products)
            {
                var productDTO = _mapper.Map<ProductDTO>(p);

                var type = await _context.Type.FindAsync(p.TypeId);
                productDTO = await productDTO.update(type, p.UserId);

                productDTOs.Add(productDTO);
            }
            return productDTOs;
        }

        // GET: products/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound("Product Id Not Found");
            }
            var productDTO = _mapper.Map<ProductDTO>(product);

            var type = await _context.Type.FindAsync(product.TypeId);
            productDTO = await productDTO.update(type, product.UserId);
            return productDTO;
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Id Mismatch");
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductItemExists(id))
                {
                    return NotFound("Product Id Not Found");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound("Product Id Not Found");
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductItemExists(long id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
