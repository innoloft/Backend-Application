using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Products.AutoMapper;
using Products.Business.Abstractions;
using Products.Entity.Models;
using Products.Entity.ViewModels;
using Products.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductBusinessModel ProductBusinessModel { get; set; }
        public IUserBusinessModel UserBusinessModel { get; set; }
        public IAddressBusinessModel AddressBusinessModel { get; set; }
        public ICompanyBusinessModel CompanyBusinessModel { get; set; }
        public IMapper Mapper { get; set; }
        public List<ProductViewModel> Products { get; set; }

        public ProductController(IProductBusinessModel productBusinessModel, 
            IUserBusinessModel userBusinessModel,
            IAddressBusinessModel addressBusinessModel,
            ICompanyBusinessModel companyBusinessModel,
            IMapper mapper)
        {
            this.ProductBusinessModel = productBusinessModel;
            this.UserBusinessModel = userBusinessModel;
            this.AddressBusinessModel = addressBusinessModel;
            this.CompanyBusinessModel = companyBusinessModel;
            this.Mapper = mapper;
            this.Products = new List<ProductViewModel>();
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductViewModel> Get()
        {
            var list = this.ProductBusinessModel.FindAll();
            foreach (var item in list.ToList())
            {
                var model = Mapper.Map<ProductViewModel>(item);
                this.Products.Add(model);
            }
            return this.Products;
        }

        // GET: api/<ProductController>
        [HttpPost]
        public IEnumerable<ProductViewModel> Get([FromQuery] PagingParameterss parameters)
        {
            var list = this.ProductBusinessModel.GetPaging(parameters);
            foreach (var item in list.ToList())
            {
                this.Products.Add(Mapper.Map<ProductViewModel>(item));
            }
            return this.Products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductViewModel Get(int id)
        {
            if (this.ProductBusinessModel.FindByCondition(i => i.Id == id).Any())
            {
                return Mapper.Map<ProductViewModel>(this.ProductBusinessModel.FindByCondition(i => i.Id == id));
            }
            else
            {
                return null;
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductViewModel value)
        {
            this.ProductBusinessModel.Create(Mapper.Map<Product>(value));
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductViewModel value)
        {
            this.ProductBusinessModel.Update(Mapper.Map<Product>(value));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id > 0 && this.ProductBusinessModel.FindByCondition(i => i.Id == id).Any())
            {
                this.ProductBusinessModel.Delete(this.ProductBusinessModel.FindByCondition(i => i.Id == id).FirstOrDefault());
            }
        }
    }
}
