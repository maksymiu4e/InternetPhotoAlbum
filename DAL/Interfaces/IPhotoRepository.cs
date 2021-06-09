using DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        /// <summary>
        /// Returns all User's Photos
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Collection of Photos</returns>
        IEnumerable<Photo> GetAllPhotosByUserId(int id);

        /// <summary>
        /// Returns all Photos created at a specific date
        /// </summary>
        /// <param name="date">yyyy-mm-dd</param>
        /// <returns>Collection of Photos</returns>
        IEnumerable<Photo> GetAllPhotosByCreationDate(DateTime date);
    }
}
