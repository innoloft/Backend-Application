using AutoMapper;
using BackendProductApi.Data;
using BackendProductApi.Helpers;
using BackendProductApi.InputModels;
using BackendProductApi.Models;
using BackendProductApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackendProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public ProductsController(ApplicationDbContext context , IMapper mapper )
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public List<ProductVM> Get()
        {
            var list = _context.Products.ToList();

            return _mapper.Map<List<ProductVM>>(list);

        }
    
        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            var product = _context.Products.Where(i => i.Id == id).FirstOrDefault();
            if (product != null)
            {
                return Ok(_mapper.Map<ProductVM>(product));
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductInputModel input)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetErrorListFromModelState.GetErrorList(ModelState));
            if (!TypesManager.checkStatus(input.Type))
                return BadRequest(new { errors = new { Type = ErrorConst.InvalidType } });
            var product = new Product
            {
                Name = input.Name,
                Description = input.Description,
                Type = input.Type,
                OwnerId = input.OwnerId
                
            };
            _context.Products.Add(product);
            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return GetCatchExceptionErrors.getErrors(this, ex);
            }

        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery][Required(ErrorMessage = ErrorConst.REQUIRED)] Guid id)
        {
            if (ModelState.IsValid)
            {
                Product product = _context.Products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    try
                    {
                        _context.Products.Remove(product);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        return GetCatchExceptionErrors.getErrors(this, ex);
                    }
                }
                else
                {
                    return BadRequest(new { errors = new { id = ErrorConst.NO_ITEM } });
                }
            }
            else
            {
                return BadRequest(GetErrorListFromModelState.GetErrorList(ModelState));
            }

        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditProductInputModel input)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetErrorListFromModelState.GetErrorList(ModelState));
            if (!TypesManager.checkStatus(input.Type))
                return BadRequest(new { errors = new { Type = ErrorConst.InvalidType } });

            var product = _context.Products.Where(i => i.Id == input.Id).FirstOrDefault();
                if (product != null)
                {
                try
                    {
                        product.Name = input.Name;
                        product.Description = input.Description;
                        product.Type = input.Type;
                        product.OwnerId = input.OwnerId;
                        _context.Products.Update(product);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        return GetCatchExceptionErrors.getErrors(this, ex);
                    }
                }
                else
                {
                    return BadRequest(new { errors = new { Id = ErrorConst.NO_ITEM } });
                }
        }
      
    }
}
