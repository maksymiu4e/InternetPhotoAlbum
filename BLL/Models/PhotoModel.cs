using Microsoft.AspNetCore.Http;
using System;

namespace BLL.Models
{
    public class PhotoModel
    {
        //public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] Content { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        //public ICollection<LikeModel> Likes { get; set; }
        //public UserModel User { get; set; }
        //public PhotoModel()
        //{

        //}
        //public PhotoModel(PhotoModelResponce model)
        //{
        //    UserId = model.UserId;
        //    Title = model.Title;
        //    Content = model.Memory();
        //}
    }
}
