using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Like, LikeModel>().ReverseMap();
            CreateMap<Photo, PhotoModel>().ReverseMap();
            //CreateMap<Role, RoleModel>().ReverseMap();
            //CreateMap<UserProfile, UserProfileModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
