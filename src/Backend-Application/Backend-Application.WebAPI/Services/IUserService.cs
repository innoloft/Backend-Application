using Backend_Application.WebAPI.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend_Application.WebAPI.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int userId);
        Task<List<UserDto>> GetUsers();
    }
}