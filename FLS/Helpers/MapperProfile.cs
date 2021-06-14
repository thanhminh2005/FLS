using AutoMapper;
using BLL.Models.User;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLS.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserInformation>().ReverseMap();
            CreateMap<User, UserProfile>().ReverseMap();
        }
    }
}
