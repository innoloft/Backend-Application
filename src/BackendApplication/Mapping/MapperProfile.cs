using AutoMapper;
using BackendApplication.Models;
using BackendApplication.Models.Dto;

namespace BackendApplication.Mapping
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            this.CreateMap<ProductInputDto, Product>()
                .ForMember(x => x.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(x => x.Id, opt => opt.MapFrom(s => string.IsNullOrWhiteSpace(s.Id) ? 0 : int.Parse(s.Id)));

            this.CreateMap<Product, ProductDto>()
                .ForPath(x => x.User.Id, opt => opt.MapFrom(s => s.UserId));

            this.CreateMap<UserDto, ShortUserDto>();
                

        }
    }
}
