﻿using AutoMapper;
using BLL.Models.User.Requests;
using BLL.Models.User.Responses;
using DAL.Entities;

namespace FLS.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserInformationResponse>().ReverseMap();
            CreateMap<User, UserProfileResponse>().ReverseMap();
            CreateMap<User, CreateUserRequest>().ReverseMap();
            CreateMap<User, CreateUserResponse>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
        }
    }
}