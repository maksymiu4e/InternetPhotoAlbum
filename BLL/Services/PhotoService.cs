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
    public class PhotoService : Service<PhotoModel, Photo>, IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IMapper _mapper;

        public PhotoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, unitOfWork.PhotoRepository, mapper)
        {
            _photoRepository = unitOfWork.PhotoRepository;
            _mapper = mapper;

            //_mapper = new Mapper(new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Photo, PhotoModel>().ReverseMap();
            //}));
        }

        public IEnumerable<PhotoModel> GetAllPhotosByCreationDate(DateTime date)
        {
            var photosByDate = _photoRepository.GetAllPhotosByCreationDate(date);
            return _mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoModel>>(photosByDate);
        }

        public IEnumerable<PhotoModel> GetAllPhotosByUserId(int id)
        {
            var photosByUser = _photoRepository.GetAllPhotosByUserId(id);
            return _mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoModel>>(photosByUser);
        }
    }
}
