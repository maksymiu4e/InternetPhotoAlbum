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
            CreateMap<UserModel, User>().ForMember(u => u.Email, opt => opt.MapFrom(um => um.Email))
                .ForMember(u => u.PasswordHash, opt => opt.MapFrom(um => um.Password))
                .ReverseMap();

            //CreateMap<UserSignUpModel, User>()
            //    .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
            //cfg.CreateMap<UserSignUpModel, UserModel>()
                        //.ForMember(u => u.Email, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}
