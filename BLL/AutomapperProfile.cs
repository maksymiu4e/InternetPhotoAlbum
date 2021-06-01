using AutoMapper;
using BLL.Models;
using BLL.Models.Photo;
using BLL.Models.User;
using DAL.Entities;
using System.IO;
using static System.Net.WebRequestMethods;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Like, LikeModel>().ReverseMap();

            CreateMap<Photo, PhotoModel>().ReverseMap();
            //CreateMap<Photo, PhotoModelResponce>().ReverseMap();

            //CreateMap<PhotoModelResponce, byte[]>()
            //    .ConstructUsing(fb =>
            //    {
            //        MemoryStream target = new MemoryStream();
            //        fb.Content.CopyTo(target);
            //        return target.ToArray();
            //    });
            //CreateMap<PhotoModel, Photo>()
            //    .ForMember(x => x.Content, opt => opt.MapFrom(x=>x).ConvertUsing(fb =>
            //    {
            //        MemoryStream target = new MemoryStream();
            //        fb.Content.CopyTo(target);
            //        return target.ToArray();
            //    }))
            //.ReverseMap();

            //CreateMap<Role, RoleModel>().ReverseMap();
            //CreateMap<UserProfile, UserProfileModel>().ReverseMap();

            CreateMap<UserModel, User>().ForMember(u => u.Email, opt => opt.MapFrom(um => um.Email))
                .ForMember(u => u.PasswordHash, opt => opt.MapFrom(um => um.Password))
                .ReverseMap();
            CreateMap<User, SignUpModel>().ReverseMap();
            CreateMap<User, SignInModel>().ReverseMap();

        }
    }
}
