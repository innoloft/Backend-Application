using BackendApplication.Models.Dto;
using System.Threading.Tasks;

namespace BackendApplication.Services
{
    public interface IAuthService
    {
        Task<string> GetTokenAsync(LoginDto input);
    }
}