using AutoMapper;
using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Like, LikeModel>().ReverseMap();
            CreateMap<Photo, PhotoModel>().ReverseMap();
            CreateMap<Role, RoleModel>().ReverseMap();
            CreateMap<UserProfile, UserProfileModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
