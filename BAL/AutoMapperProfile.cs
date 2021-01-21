using AutoMapper;
using BAL.ViewModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductVM>();
            CreateMap<ProductVM, Product>();
        }
    }
}
