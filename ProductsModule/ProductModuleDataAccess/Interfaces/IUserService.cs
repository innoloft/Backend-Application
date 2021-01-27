using ProductModuleDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductModuleDataAccess.Interfaces
{
    public interface IUserService
    {
        Task<User> GetById(int id);
    }
}
