using AutoMapper;
using InnoloftTask.Models;

namespace InnoloftTask
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}