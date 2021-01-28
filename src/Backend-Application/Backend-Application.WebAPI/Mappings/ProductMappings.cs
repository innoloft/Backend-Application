using AutoMapper;
using Backend_Application.WebAPI.Dtos;
using Backend_Application.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Type = Backend_Application.WebAPI.Entities.Type;

namespace Backend_Application.WebAPI.Mappings
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(p => p.ProductId));
            CreateMap<Type, ProductTypeDto>().ForMember(dto => dto.Id, opt => opt.MapFrom(t => t.TypeId));
            CreateMap<UserDto, ProductUserDto>().ForMember(dto => dto.ContactInformation, opt => opt.MapFrom(u => u.Phone));
        }
    }
}
