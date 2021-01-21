using System;
using System.Collections.Generic;
using System.Linq;
using InnoLoft.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using BAL.Interface;
using BAL.ViewModels;
using Microsoft.AspNetCore.Http;

namespace InnoLoft.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        public readonly IConfiguration _configuration;
        public readonly IWebHostEnvironment _hostingEnvironment;
        public readonly IServiceProvider _serviceProvider;
        IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository, IServiceProvider serviceProvider)
        {
            _productRepository = productRepository;
            _serviceProvider = serviceProvider;
            _configuration = (IConfiguration)this._serviceProvider.GetService(typeof(IConfiguration));
            _hostingEnvironment = (IWebHostEnvironment)this._serviceProvider.GetService(typeof(IWebHostEnvironment));
        }

        /// <summary>
        /// Get product list by filter
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Get(ProductSearchRequest searchRequest)
        {
            CommonResponse<List<ProductVM>> response = new CommonResponse<List<ProductVM>>();
            try
            {
                if (searchRequest != null)
                {
                    var result = _productRepository.Get();
                    if (result != null)
                    {
                        response.totalRecords = result.Count;
                        response.status = Helper.success_code;

                        if (searchRequest.typeId > 0)
                        {
                            result = result.Where(x => x.TypeId == searchRequest.typeId).ToList();
                            response.totalRecords = result.Count;
                        }

                        var take = searchRequest.rows != 0 ? searchRequest.rows : 10;

                        if (searchRequest.filterColumn == null && searchRequest.search != null && searchRequest.search != string.Empty)
                        {
                            var search = searchRequest.search;
                            result = result.Where(x => x.ContactPersonName.ToLower().Contains(search.ToLower())).ToList();
                            response.totalRecords = result.Count;
                        }

                        if (searchRequest.sortOrder != 0)
                        {
                            result = searchRequest.sortOrder == -1 ? result.OrderByDescending(p => p.CreatedDate).ToList() : result.OrderBy(p => p.CreatedDate).ToList();
                            response.totalRecords = result.Count;
                        }

                        result = result.Take(take).ToList();

                        response.dataenum = result;
                    }
                    else
                    {
                        response.message = Entity.Product + Message.notFound;
                        response.status = Helper.failure_code;
                    }
                }
                else
                {
                    response.message = Message.badRequest;
                }
            }
            catch (Exception ex)
            {
                response.status = Helper.failure_code;
                response.message = ex.ToString();
            }
            return Ok(response);
        }


        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Int64 id)
        {
            CommonResponse<ProductVM> response = new CommonResponse<ProductVM>();
            try
            {
                if (id > 0)
                {
                    var result = _productRepository.GetById(id);
                    if (result != null)
                    {
                        response.status = Helper.success_code;
                        response.message = Entity.Product + Message.found;
                        response.dataenum = result;
                    }
                    else
                    {
                        response.message = Entity.Product + Message.notFound;
                    }
                }
                else
                {
                    response.status = Helper.badrequest_code;
                    response.message = Message.badRequest;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.ToString();
            }
            return Ok(response);
        }

        /// <summary>
        /// Save/Update Product
        /// </summary>
        /// <param name="ProductVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Save(ProductVM productVM)
        {
            CommonResponse<int> response = new CommonResponse<int>();
            try
            {
                if (productVM != null)
                {
                    int LoginUserId = 0;
                    if (productVM.Id > 0)
                    {
                        var result = _productRepository.Update(productVM, LoginUserId);
                        if (result != 0)
                        {
                            response.status = Helper.success_code;
                            response.message = Entity.Product + Message.updated;
                        }
                        else
                        {
                            response.message = Entity.Product + Message.updatedError;
                            response.status = Helper.failure_code;
                        }
                    }
                    else
                    {
                        var result = _productRepository.Save(productVM, LoginUserId);
                        if (result != 0)
                        {
                            response.status = Helper.success_code;
                            response.message = Entity.Product + Message.added;
                        }
                        else
                        {
                            response.message = Entity.Product + Message.addedError;
                            response.status = Helper.failure_code;
                        }
                    }
                }
                else
                {
                    response.status = Helper.badrequest_code;
                    response.message = Message.badRequest;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.ToString();
                response.status = Helper.badrequest_code;
            }
            return Ok(response);
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Int64 id)
        {
            CommonResponse<int> response = new CommonResponse<int>();
            try
            {
                if (id > 0)
                {
                    int LoginUserId = 0;
                    var result = _productRepository.Delete(id, LoginUserId);
                    if (result != 0)
                    {
                        response.status = Helper.success_code;
                        response.message = Entity.Product + Message.deleted;
                    }
                    else
                    {
                        response.message = Entity.Product + Message.deletedError;
                        response.status = Helper.failure_code;
                    }
                }
                else
                {
                    response.status = Helper.badrequest_code;
                    response.message = Message.badRequest;
                }
            }
            catch (Exception ex)
            {
                response.status = Helper.failure_code;
                response.message = ex.ToString();
            }
            return Ok(response);
        }

    }
}
