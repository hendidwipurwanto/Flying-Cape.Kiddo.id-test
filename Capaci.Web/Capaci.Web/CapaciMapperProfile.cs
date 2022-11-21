using AutoMapper;
using Capaci.DTO.Models;
using Capaci.DTO.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Capaci.Web
{
    public class CapaciMapperProfile:Profile
    {
        public CapaciMapperProfile()
        {
            CreateMap<IdentityUser, IdentityUser>().ReverseMap();
            CreateMap<RegisterViewModel, UserDetail>().ReverseMap();
            CreateMap<UserDetailViewModel, UserDetail>().ReverseMap();
            CreateMap<UserDetailViewModel, UserDetailViewModel>().ReverseMap();
            CreateMap<RegisterViewModel,UserDetailViewModel>().ReverseMap();
            CreateMap<UserDetail, UserDetail>().ReverseMap();
            CreateMap<Product, Product>().ReverseMap();
            CreateMap<ProductViewModel, Product>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ProductViewModel, ProductViewModel>().ReverseMap();

        }
    }
}
