using System;

namespace BLL.Models
{
    public class PhotoModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] Content { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
