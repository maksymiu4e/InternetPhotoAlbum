using DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        IEnumerable<Photo> GetAllPhotosByUserId(int id);
        IEnumerable<Photo> GetAllPhotosByCreationDate(DateTime date);
    }
}
