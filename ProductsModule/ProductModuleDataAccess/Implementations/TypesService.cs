using ProductModuleDataAccess.Interfaces;
using ProductModuleDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModuleDataAccess.Implementations
{
    public class TypesService : ITypesService
    {
        private readonly ProducrModuleDbContext _dbContext;

        public TypesService(ProducrModuleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Types> GetAllTypes()
        {
            var allTypes = _dbContext.types.ToList();

            return allTypes;
        }
    }
}
