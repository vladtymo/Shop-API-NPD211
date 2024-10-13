using AutoMapper;
using Data.Entities;
using Core.Models;

namespace Core.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<CreateProductModel, Product>();
            CreateMap<EditProductModel, Product>();
            CreateMap<Product, ProductModel>();

            CreateMap<RegisterModel, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(x => x.PasswordHash, opt => opt.Ignore());
        }
    }
}
