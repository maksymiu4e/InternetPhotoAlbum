﻿using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IPhotoService : IService<PhotoModel>
    {
        IEnumerable<PhotoModel> GetAllPhotosByUserId(int id);
        IEnumerable<PhotoModel> GetAllPhotosByRoleId(int id);
        IEnumerable<PhotoModel> GetAllPhotosByCreationDate(DateTime date);
    }
}