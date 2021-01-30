using BackendApplication.Models.Dto;
using System.Threading.Tasks;

namespace BackendApplication.Clients
{
    public interface IUserClient
    {
        Task<UserDto> GetUserInfoAsync(int id);
    }
}