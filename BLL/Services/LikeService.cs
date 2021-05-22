using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LikeService : Service<LikeModel>, ILikeService
    {
        public IEnumerable<LikeModel> GetAllLikesByPhotoId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LikeModel> GetAllLikesByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
