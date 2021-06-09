using BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPhotoService : IService<PhotoModel>
    {
        /// <summary>
        /// Returns all User's Photos
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Collection of Photos</returns>
        IEnumerable<PhotoModel> GetAllPhotosByUserId(int id);

        /// <summary>
        /// Returns all Photos created at a specific date
        /// </summary>
        /// <param name="date">yyyy-mm-dd</param>
        /// <returns>Collection of Photos</returns>
        IEnumerable<PhotoModel> GetAllPhotosByCreationDate(DateTime date);

        /// <summary>
        /// Posts new photo.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Message about status</returns>
        Task<string> PostNewPhoto(PhotoModel model);
    }
}
