using AutoMapper;
using Moq;
using NUnit.Framework;
using Products.Api.Controllers;
using Products.AutoMapper;
using Products.Business.Abstractions;
using Products.Business.Implementations;
using Products.Entity.Models;
using Products.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Products.Tests
{
    [TestFixture]
    public class ProductControllerTests
    {
        List<Product> Products = new List<Product>();
        [SetUp]
        public void SetUp()
        {
            this.Products.Add(new Product()
            {
                Description = "sample",
                Id = 1,
                Name = "Sample",
                Type = "Software",
                User = new User()
                {
                    Address = new Address()
                    {
                        City = "Sample",
                        Id = 1,
                        Latitude = "sample",
                        Longitude = "Sample",
                        Street = "sample",
                        Suite = "Sample",
                        Zipcode = "sample"
                    },
                    AddressId = 1,
                    Company = new Company()
                    {
                        Bs = "Sample",
                        Id = 1,
                        CacthPhrase = "sample",
                        Name = "sample"
                    },
                    Name = "Sample",
                    Id = 1,
                    CompanyId = 1,
                    Email = "sample@sample.com",
                    Phone = "00000000000",
                    UserName = "sampleid",
                    Website = "sample.com"
                },
                UserId = 1
            });
        }

        [Test]
        public void GetTest()
        {
            var paging = new Helpers.PagingParameterss();
            var service = new Mock<IProductBusinessModel>();
            service.Setup(i => i.FindAll()).Returns(this.Products.AsQueryable());
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            var mapper = mockMapper.CreateMapper();
            //var service = Mock.Of<ProductBusinessModel>(i=>i.GetPaging(It.IsAny<Helpers.PagingParameterss>())
            var controller = new ProductController(service.Object, null, null, null, mapper);
            Assert.IsNotNull(controller.Get().ToList());

        }
    }
}
