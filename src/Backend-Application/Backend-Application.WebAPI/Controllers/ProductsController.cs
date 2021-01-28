using Backend_Application.WebAPI.Data;
using Backend_Application.WebAPI.Dtos;
using Backend_Application.WebAPI.Entities;
using Backend_Application.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Backend_Application.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        private IUserService _userService;

        private IMapper _mapper;
        public ProductsController(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductDto dto)
        {
            var type = _unitOfWork.Repository<Entities.Type>().Get(dto.TypeId);
            if (type == null)
            {
                return BadRequest();
            }

            var user = await _userService.GetUser(dto.ContactPersonId);
            if(user is null)
            {
                return BadRequest();
            }

            var productModel = new Product(dto.Title, dto.Description, dto.ContactPersonId , type);
            _unitOfWork.Repository<Product>().Add(productModel);
            await _unitOfWork.CompleteAsync();

            var productDto = _mapper.Map<ProductDto>(productModel);
            var userDto = _mapper.Map<ProductUserDto>(user);
            productDto.User = userDto;

            return Created($"/{productModel.ProductId}", productDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _unitOfWork.Repository<Product>().Table.Include(p => p.Type).FirstOrDefaultAsync(p => p.ProductId == id);
            var productDto = _mapper.Map<ProductDto>(product);

            var user = await _userService.GetUser(product.OwnerId);
            var userDto = _mapper.Map<ProductUserDto>(user);
            productDto.User = userDto;
            return Ok(productDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll (int page = 0)
        {
            var products = await _unitOfWork.Repository<Product>().Table.Skip(page * 10).Take(10).Include(p => p.Type).ToListAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products);

            var users = await _userService.GetUsers();
            var usersDtos = _mapper.Map<List<ProductUserDto>>(users);

            productsDto.ForEach(p => p.User = usersDtos.FirstOrDefault(u => u.Id == products.FirstOrDefault(pp => pp.ProductId == p.Id).OwnerId));

            return Ok(productsDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            var type = _unitOfWork.Repository<Entities.Type>().Get(dto.TypeId);
            if (type == null)
            {
                return BadRequest();
            }

            var user = await _userService.GetUser(dto.ContactPersonId);
            if (user is null)
            {
                return BadRequest();
            }


            var productModel = _unitOfWork.Repository<Product>().Get(dto.ProductId);
            productModel.Update(dto.Title, dto.Description, dto.ContactPersonId, type);
            await _unitOfWork.CompleteAsync();


            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = _unitOfWork.Repository<Product>().Get(id);
            if(product is null)
            {
                return BadRequest();
            }

            _unitOfWork.Repository<Product>().Delete(product);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }
    }
}
