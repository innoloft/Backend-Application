using AutoMapper;
using Products.Entity.Models;
using Products.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Address, AddressViewModel>()
                .ForMember(i => i.City, i => i.MapFrom(j => j.City))
                .ForMember(i => i.Street, i => i.MapFrom(j => j.Street))
                .ForMember(i => i.Suite, i => i.MapFrom(j => j.Suite))
                .ForMember(i => i.Zipcode, i => i.MapFrom(j => j.Zipcode));
            CreateMap<Address, Geo>()
                .ForMember(i => i.Latitude, i => i.MapFrom(j => j.Latitude))
                .ForMember(i => i.Longitude, i => i.MapFrom(j => j.Longitude));
            CreateMap<CompanyViewModel, Company>();
            CreateMap<UserViewModel, User>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
