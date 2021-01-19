namespace ProductAPI.Interfaces
{
    using System.Threading.Tasks;
    using ProductAPI.Models;

    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string userName);       
    }
}