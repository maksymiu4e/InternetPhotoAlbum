using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class UserService : Service<UserModel, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.UserRepository)
        {
            _userRepository = unitOfWork.UserRepository;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserModel>().ReverseMap();
            }));
        }

    }
}
