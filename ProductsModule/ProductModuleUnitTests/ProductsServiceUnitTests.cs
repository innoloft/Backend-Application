using Moq;
using ProductModuleDataAccess.Implementations;
using ProductModuleDataAccess.Interfaces;
using ProductModuleDataAccess.Models;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ProductModuleUnitTests
{
    public class ProductsServiceUnitTests
    {
        private readonly ITestOutputHelper _output;
        private IProductsService _productsService;

        public ProductsServiceUnitTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData(3)]
        public async Task GetById_VerifyOutput(int id)
        {
            //Arrange
            var productToReturn = new Products
            {
                name = "Test Product",
                description = "New test product description",
                Type = new Types { name = "Test type"},
                Contact = new Contacts { name = "Test contacts"}
            };

            var mockproductService = new Mock<IProductsService>();
            mockproductService
                .Setup(s => s.GetById(id))
                .ReturnsAsync(productToReturn);
            _productsService = mockproductService.Object;

            //Act
            var result = await _productsService.GetById(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Test Product", result.name);

            _output.WriteLine(result.ToString());
        }
    }
}
