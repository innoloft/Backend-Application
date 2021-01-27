using AutoMapper;
using ProductModuleDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsModuleApi.Model
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductModel, Products>();
        }
    }
}
