namespace ProductAPI.Services
{
    using System.Threading.Tasks;
    using ProductAPI.Interfaces;
    using ProductAPI.Models;

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepo;
        private readonly ITokenService tokenService;

        public UserService(IUserRepository injectedUserRepo, ITokenService injectedTokenService)
        {
            userRepo = injectedUserRepo;
            tokenService = injectedTokenService;
        }

        public async Task<string> AuthenticateUserAsync(UserLoginModel user)
        {
            User userData = await userRepo.GetUserByUsernameAsync(user.userName);

            if (userData != null && userData.isValidPassword(user.password))
            {
                return tokenService.GenerateToken(userData.id);
            }

            return null;
        }
    }
}