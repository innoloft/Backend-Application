using AutoMapper;
using Innoloft.Api.Models;
using Innoloft.Interfaces.Entities;

namespace Innoloft.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, PersonModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductType, ProductTypeModel>().ReverseMap();
        }
    }
}
