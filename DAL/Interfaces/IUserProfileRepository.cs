using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        IEnumerable<UserProfile> GetByUserId(int id);
    }
}
