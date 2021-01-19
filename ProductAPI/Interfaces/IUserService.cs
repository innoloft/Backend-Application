namespace ProductAPI.Interfaces
{
    using System.Threading.Tasks;
    using ProductAPI.Models;

    public interface IUserService
    {
        Task<string> AuthenticateUserAsync(UserLoginModel user);
    }
}