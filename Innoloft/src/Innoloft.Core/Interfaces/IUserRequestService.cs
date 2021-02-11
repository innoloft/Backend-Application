using Innoloft.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Innoloft.Core.Interfaces
{
    public interface IUserRequestService
    {
        Task<UserDetailDto> GetUser(int userId);
        Task<List<UserDetailDto>> GetUsers();
    }
}
