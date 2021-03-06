using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] Content { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual User User { get; set; }
    }
}
