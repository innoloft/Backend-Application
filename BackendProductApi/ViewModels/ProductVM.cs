using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProductApi.ViewModels
{
    public class ProductVM
    {
        public Guid Id { get; set; }

        
        public string Name { get; set; }

        
        public string Description { get; set; }

        
        public string Type { get; set; }

        
        

        
        public string AppUserFullName { get; set; }

        public string AppUserPhoneNumber { get; set; }
    }
}
