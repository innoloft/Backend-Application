using AutoMapper;
using Backend_Application.WebAPI.Controllers;
using Backend_Application.WebAPI.Data;
using Backend_Application.WebAPI.Dtos;
using Backend_Application.WebAPI.Entities;
using Backend_Application.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Type = Backend_Application.WebAPI.Entities.Type;

namespace Backend_Application.UnitTests
{
    public class ProductsControllerTests
    {

        [Fact]
        public async Task Create_TypeDoesNotExists_ShouldReturnBadRequest()
        {
            // arrange 
            var unitOfWork = new Mock<IUnitOfWork>();
            var typerepo = new Mock<IRepository<Type>>();
            var productsController = new ProductsController(unitOfWork.Object, null, null);

            var productDto = new AddProductDto
            {
                TypeId = int.MaxValue
            };
            typerepo.Setup(r => r.Get(int.MaxValue)).Returns(null as Type);
            unitOfWork.Setup(u => u.Repository<Type>()).Returns(typerepo.Object);
            var result =await  productsController.Create(productDto);

            Assert.IsType<BadRequestResult>(result);
        }      
        
        [Fact]
        public async Task Create_UserDoesNotExists_ShouldReturnBadRequest()
        {
            // arrange 
            var unitOfWork = new Mock<IUnitOfWork>();
            var typerepo = new Mock<IRepository<Type>>();
            var userService = new Mock<IUserService>();
            var productsController = new ProductsController(unitOfWork.Object, userService.Object, null);
      
            var productDto = new AddProductDto
            {
                TypeId = 1,
                ContactPersonId = int.MaxValue
            };
            typerepo.Setup(r => r.Get(1)).Returns(new Type("Hello", "ImageRrl"));
            unitOfWork.Setup(u => u.Repository<Type>()).Returns(typerepo.Object);
            userService.Setup(s => s.GetUser(int.MaxValue)).ReturnsAsync(null as UserDto);

            var result =await  productsController.Create(productDto);

            userService.Verify(s => s.GetUser(int.MaxValue), Times.Once());
            Assert.IsType<BadRequestResult>(result);
        }    
    }
}
