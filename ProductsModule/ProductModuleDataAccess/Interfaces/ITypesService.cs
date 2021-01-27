using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProductModuleDataAccess.Models;

namespace ProductModuleDataAccess.Interfaces
{
    public interface ITypesService
    {
        List<Types> GetAllTypes();
    }
}
