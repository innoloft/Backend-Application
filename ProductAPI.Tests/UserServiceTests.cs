namespace ProductAPI.Tests
{
    using System;
    using System.Threading.Tasks;
    using Moq;
    using ProductAPI.Interfaces;
    using ProductAPI.Models;
    using ProductAPI.Services;
    using Xunit;

    public class UserServiceTests
    {
        [Theory,
            InlineData("abc", "abc"),
            InlineData("pass@123", "pass@123")]
        public void AuthenticateUserAsync_ReturnsToken_WhenPasswordIsSame(string password, string inputPassword)
        {
            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(repo => repo.GetUserByUsernameAsync(It.IsAny<string>()))
                        .ReturnsAsync(GetTestUser(password));
            var mockTokenService = new Mock<ITokenService>();
            mockTokenService.Setup(tokenService => tokenService.GenerateToken(It.IsAny<int>()))
                        .Returns(new Random().Next(8).ToString());
            UserLoginModel userModel = new UserLoginModel() { password = inputPassword };
            

            IUserService userService = new UserService(mockUserRepo.Object, mockTokenService.Object);

            Assert.NotNull(userService.AuthenticateUserAsync(userModel).Result);
        }

        [Theory,
            InlineData("abc", "abcd"),
            InlineData("pass@123", "pass@1234")]
        public void AuthenticateUserAsync_ReturnsNull_WhenPasswordIsDifferent(string password, string inputPassword)
        {
            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(repo => repo.GetUserByUsernameAsync(It.IsAny<string>()))
                        .ReturnsAsync(GetTestUser(password));
            var mockTokenService = new Mock<ITokenService>();
            mockTokenService.Setup(tokenService => tokenService.GenerateToken(It.IsAny<int>()))
                        .Returns(new Random().Next(8).ToString());
            UserLoginModel userModel = new UserLoginModel() { password = inputPassword };
            

            IUserService userService = new UserService(mockUserRepo.Object, mockTokenService.Object);

            Assert.Null(userService.AuthenticateUserAsync(userModel).Result);
        }

        [Fact]
        public void AuthenticateUserAsync_ReturnsNull_WhenUserNameNotFound()
        {
            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(repo => repo.GetUserByUsernameAsync(It.IsAny<string>()))
                        .ReturnsAsync((User)null);
            var mockTokenService = new Mock<ITokenService>();
            mockTokenService.Setup(tokenService => tokenService.GenerateToken(It.IsAny<int>()))
                        .Returns(new Random().Next(8).ToString());
            UserLoginModel userModel = new UserLoginModel() { password = It.IsAny<string>() };
            

            IUserService userService = new UserService(mockUserRepo.Object, mockTokenService.Object);

            Assert.Null(userService.AuthenticateUserAsync(userModel).Result);
        }

        private User GetTestUser(string password)
        {
            return new User()
            {
                id = 1,
                password = password
            };
        }
    }
}