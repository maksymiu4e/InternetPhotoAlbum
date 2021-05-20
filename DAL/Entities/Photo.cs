using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] Content { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Like> Likes { get; set; }
        public User User { get; set; }
    }
}
