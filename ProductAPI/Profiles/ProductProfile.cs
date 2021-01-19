
namespace ProductAPI.Profiles
{
    using AutoMapper;
    using ProductAPI.Models;

    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreationModel, Product>();
            CreateMap<ProductUpdateModel, Product>();
        }
    }
}