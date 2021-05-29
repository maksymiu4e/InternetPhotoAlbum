using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class UserService : Service<UserModel, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager) : base(unitOfWork, unitOfWork.UserRepository, mapper)
        {
            _userRepository = unitOfWork.UserRepository;
            _mapper = mapper;
            _userManager = userManager;
            //_mapper = new Mapper(new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<User, UserModel>().ReverseMap();
            //}));
        }

    }
}
