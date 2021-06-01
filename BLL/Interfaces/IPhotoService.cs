using BLL.Models.Photo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPhotoService : IService<PhotoModel>
    {
        IEnumerable<PhotoModel> GetAllPhotosByUserId(int id);
        //IEnumerable<PhotoModel> GetAllPhotosByRoleId(int id);
        IEnumerable<PhotoModel> GetAllPhotosByCreationDate(DateTime date);
        
        /// <summary>
        /// Posts new photo.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Message about status</returns>
        Task<string> PostNewPhoto(PhotoModel model);
    }
}
