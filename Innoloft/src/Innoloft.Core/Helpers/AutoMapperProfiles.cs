using AutoMapper;
using Innoloft.Core.DTOs;
using Innoloft.Core.Models;

namespace Innoloft.Core.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDetailDto>();
            CreateMap<Product, ProductListDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();

            CreateMap<ProductType, ProductTypeDetailDto>();
        }
    }
}
