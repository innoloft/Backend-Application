using AutoMapper;
using Innoloft.Api.Helpers;
using Innoloft.Api.Models;
using Innoloft.Interfaces.Entities;
using Innoloft.Interfaces.Services;
using Innoloft.Repositories.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Innoloft.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ProductsController(
            IProductService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _service = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]ProductFilters filters)
        {
            var products = _service.GetByFilter(filters);
            var productList = _mapper.Map<IList<ProductModel>>(products.Item1);
            return Ok(new { Data = productList, Count = products.Item2 });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _service.GetById(id);
            var productModel = _mapper.Map<ProductModel>(product);
            return Ok(productModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);
            try
            {
                return Ok(_mapper.Map<ProductModel>(_service.Create(product)));
            }
            catch (RepositoryException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);
            product.Id = id;

            try
            {
                _service.Update(product);
                return Ok();
            }
            catch (RepositoryException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}