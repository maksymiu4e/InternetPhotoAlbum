using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

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

        ///<inheritdoc/>
        public async Task<string> PostNewPhoto(PhotoModel model)
        {
            Photo photo = new Photo
            {
                UserId = model.UserId,
                Title = model.Title,
                //Content = Memory(model.Content),
                CreationDate = DateTime.Now
                
            };

            try
            {
                await _photoRepository.CreateAsync(photo);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {

                return "Failed to upload photo";
            }

            return "Photo created successfully";
        }

        public byte[] Memory(IFormFile file)
        {
            byte[] bytes = null;
            using (Stream img = file.OpenReadStream())
            using (MemoryStream memmoryStream = new MemoryStream())
            {
                img.CopyTo(memmoryStream);
                bytes = memmoryStream.ToArray();
            }
            return bytes;
        }
    }
}
