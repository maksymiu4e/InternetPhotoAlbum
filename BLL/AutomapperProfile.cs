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

            CreateMap<UserModel, User>()
                .ForMember(u => u.PasswordHash, opt => opt.MapFrom(um => um.Password))
                .ReverseMap();
            //CreateMap<User, SignUpModel>().ReverseMap();
            //CreateMap<User, SignInModel>().ReverseMap();
            //CreateMap<UserModel, SignInViewModel>().ReverseMap();

        }
    }
}
