using AutoMapper;
using Innoloft.Core.Helpers;
using Innoloft.Core.Interfaces;
using Innoloft.Core.Models;
using Innoloft.WebAPI.Controllers;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Innoloft.UnitTests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnit;
        private readonly ProductsController _productsController;
        private readonly Mock<IProductRepository> _mockProdRepo;
        private readonly Mock<IUserRequestService> _mockUserReq;

        public ProductsControllerTests()
        {
            _mockUnit = new Mock<IUnitOfWork>();
            _mockProdRepo = new Mock<IProductRepository>();
            _mockUserReq = new Mock<IUserRequestService>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var mapper = mockMapper.CreateMapper();

            _productsController = new ProductsController(_mockUnit.Object, _mockUserReq.Object, mapper);
        }

        [Fact]
        public async Task Get_Product_ShouldReturnNotNull()
        {
            _mockProdRepo.Setup(r => r.GetByIdAsync(1).Result).Returns(new Product());
            _mockUnit.Setup(u => u.Products.GetProductWithTypeByIdAsync(1)).ReturnsAsync(new Product());

            var result = await _productsController.GetProduct(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Get_Products_ShouldReturnNotNull()
        {
            PagingParams pagingParams = new PagingParams()
            {
                PageSize = 2,
                Number = 1
            };

            _mockProdRepo.Setup(r => r.GetAllAsync().Result).Returns(new List<Product>());
            _mockUnit.Setup(u => u.Products.GetProductsWithTypeAsync().Result).Returns(new List<Product>());

            var result = await _productsController.GetProducts(pagingParams);

            Assert.NotNull(result);
        }
    }
}
