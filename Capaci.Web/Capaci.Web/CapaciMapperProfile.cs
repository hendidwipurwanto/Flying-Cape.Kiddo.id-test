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

        }
    }
}
