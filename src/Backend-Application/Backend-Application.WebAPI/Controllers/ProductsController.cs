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

    }
}
