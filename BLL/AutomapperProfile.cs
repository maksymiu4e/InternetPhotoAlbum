using AutoMapper;
using BLL.Models;
using BLL.Models.Photo;
using BLL.Models.User;
using DAL.Entities;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Like, LikeModel>().ReverseMap();

            CreateMap<Photo, PhotoModel>().ReverseMap();

            CreateMap<UserModel, User>().ForMember(u => u.Email, opt => opt.MapFrom(um => um.Email))
                .ForMember(u => u.PasswordHash, opt => opt.MapFrom(um => um.Password))
                .ReverseMap();
            CreateMap<User, SignUpModel>().ReverseMap();
            CreateMap<User, SignInModel>().ReverseMap();

        }
    }
}
